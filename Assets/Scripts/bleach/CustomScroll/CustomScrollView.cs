﻿using UnityEngine;


public class CustomScrollView : MonoBehaviour
{
    public enum Movement
    {
        Horizontal,
        Vertical,
        Unrestricted,
        Custom,
    }

    public enum DragEffect
    {
        None,
        Momentum,
        MomentumAndSpring,
    }

    public enum ShowCondition
    {
        Always,
        OnlyIfNeeded,
        WhenDragging,
    }

    public delegate void OnDragFinished();


    public Movement movement = Movement.Vertical;


    public DragEffect dragEffect = DragEffect.MomentumAndSpring;


    public bool restrictWithinPanel = true;


    public bool disableDragIfFits = false;

    public bool smoothDragStart = true;

    public bool iOSDragEmulation = true;

    public float scrollWheelFactor = 0.25f;

    public float momentumAmount = 35f;

    public UIScrollBar horizontalScrollBar;

    public UIScrollBar verticalScrollBar;

    public ShowCondition showScrollBars = ShowCondition.OnlyIfNeeded;

    public Vector2 customMovement = new Vector2(1f, 0f);

    public Vector2 relativePositionOnReset = Vector2.zero;

    public OnDragFinished onDragFinished;

    [HideInInspector]
    [SerializeField]
    Vector3 scale = new Vector3(0f, 0f, 0f);

    Transform mTrans;
    UIPanel mPanel;
    Plane mPlane;
    Vector3 mLastPos;
    bool mPressed = false;
    Vector3 mMomentum = Vector3.zero;
    float mScroll = 0f;
    Bounds mBounds;
    //bool mCalculatedBounds = false;
    bool mShouldMove = false;
    bool mIgnoreCallbacks = false;
    int mDragID = -10;
    Vector2 mDragStartOffset = Vector2.zero;
    bool mDragStarted = false;

    public UIPanel panel { get { return mPanel; } }

    public Bounds bounds
    {
        get
        {
            return mBounds;
        }
        set
        {
            mBounds = value;
        }
    }

    public bool canMoveHorizontally
    {
        get
        {
            return movement == Movement.Horizontal ||
                movement == Movement.Unrestricted ||
                (movement == Movement.Custom && customMovement.x != 0f);
        }
    }

    public bool canMoveVertically
    {
        get
        {
            return movement == Movement.Vertical ||
                movement == Movement.Unrestricted ||
                (movement == Movement.Custom && customMovement.y != 0f);
        }
    }

    public virtual bool shouldMoveHorizontally
    {
        get
        {
            float size = bounds.size.x;
            if (mPanel.clipping == UIDrawCall.Clipping.SoftClip) size += mPanel.clipSoftness.x * 2f;
            return size > mPanel.width;
        }
    }

    public virtual bool shouldMoveVertically
    {
        get
        {
            float size = bounds.size.y;
            if (mPanel.clipping == UIDrawCall.Clipping.SoftClip) size += mPanel.clipSoftness.y * 2f;
            return size > mPanel.height;
        }
    }

    protected virtual bool shouldMove
    {
        get
        {
            if (!disableDragIfFits) return true;

            if (mPanel == null) mPanel = GetComponent<UIPanel>();
            Vector4 clip = mPanel.finalClipRegion;
            Bounds b = bounds;

            float hx = (clip.z == 0f) ? Screen.width : clip.z * 0.5f;
            float hy = (clip.w == 0f) ? Screen.height : clip.w * 0.5f;

            if (canMoveHorizontally)
            {
                if (b.min.x < clip.x - hx) return true;
                if (b.max.x > clip.x + hx) return true;
            }

            if (canMoveVertically)
            {
                if (b.min.y < clip.y - hy) return true;
                if (b.max.y > clip.y + hy) return true;
            }
            return false;
        }
    }

    public Vector3 currentMomentum { get { return mMomentum; } set { mMomentum = value; mShouldMove = true; } }

    void Awake()
    {
        mTrans = transform;
        mPanel = GetComponent<UIPanel>();

        if (mPanel.clipping == UIDrawCall.Clipping.None)
            mPanel.clipping = UIDrawCall.Clipping.ConstrainButDontClip;

        if (movement != Movement.Custom && scale.sqrMagnitude > 0.001f)
        {
            if (scale.x == 1f && scale.y == 0f)
            {
                movement = Movement.Horizontal;
            }
            else if (scale.x == 0f && scale.y == 1f)
            {
                movement = Movement.Vertical;
            }
            else if (scale.x == 1f && scale.y == 1f)
            {
                movement = Movement.Unrestricted;
            }
            else
            {
                movement = Movement.Custom;
                customMovement.x = scale.x;
                customMovement.y = scale.y;
            }
            scale = Vector3.zero;
#if UNITY_EDITOR
			UnityEditor.EditorUtility.SetDirty(this);
#endif
        }
    }

    void OnDestroy()
    {

    }

    void OnPanelChange() { UpdateScrollbars(true); }

    void Start()
    {
        if (Application.isPlaying)
        {
            UpdateScrollbars(true);

            if (horizontalScrollBar != null)
            {
                EventDelegate.Add(horizontalScrollBar.onChange, OnHorizontalBar);
                horizontalScrollBar.alpha = ((showScrollBars == ShowCondition.Always) || shouldMoveHorizontally) ? 1f : 0f;
            }

            if (verticalScrollBar != null)
            {
                EventDelegate.Add(verticalScrollBar.onChange, OnVerticalBar);
                verticalScrollBar.alpha = ((showScrollBars == ShowCondition.Always) || shouldMoveVertically) ? 1f : 0f;
            }
        }
    }

    public bool RestrictWithinBounds(bool instant) { return RestrictWithinBounds(instant, true, true); }

    public bool RestrictWithinBounds(bool instant, bool horizontal, bool vertical)
    {
        Bounds b = bounds;
        Vector3 constraint = mPanel.CalculateConstrainOffset(b.min, b.max);

        if (!horizontal) constraint.x = 0f;
        if (!vertical) constraint.y = 0f;

        if (constraint.magnitude > 1f)
        {
            if (!instant && dragEffect == DragEffect.MomentumAndSpring)
            {
                Vector3 pos = mTrans.localPosition + constraint;
                pos.x = Mathf.Round(pos.x);
                pos.y = Mathf.Round(pos.y);
                SpringPanel.Begin(mPanel.gameObject, pos, 13f);
            }
            else
            {
                MoveRelative(constraint);
                mMomentum = Vector3.zero;
                mScroll = 0f;
            }
            return true;
        }
        return false;
    }

    public void DisableSpring()
    {
        SpringPanel sp = GetComponent<SpringPanel>();
        if (sp != null) sp.enabled = false;
    }

    public virtual void UpdateScrollbars(bool recalculateBounds)
    {
        if (mPanel == null) return;

        if (horizontalScrollBar != null || verticalScrollBar != null)
        {
            if (recalculateBounds)
            {
                //mCalculatedBounds = false;
                mShouldMove = shouldMove;
            }

            Bounds b = bounds;
            Vector2 bmin = b.min;
            Vector2 bmax = b.max;

            if (horizontalScrollBar != null && bmax.x > bmin.x)
            {
                Vector4 clip = mPanel.finalClipRegion;
                float extents = clip.z * 0.5f;

                if (mPanel.clipping == UIDrawCall.Clipping.SoftClip)
                    extents -= mPanel.clipSoftness.x;

                float min = clip.x - extents - b.min.x;
                float max = b.max.x - extents - clip.x;

                float width = bmax.x - bmin.x;
                min = Mathf.Clamp01(min / width);
                max = Mathf.Clamp01(max / width);

                float sum = min + max;
                mIgnoreCallbacks = true;
                horizontalScrollBar.barSize = 1f - sum;
                horizontalScrollBar.value = (sum > 0.001f) ? min / sum : 0f;
                mIgnoreCallbacks = false;
            }

            if (verticalScrollBar != null && bmax.y > bmin.y)
            {
                Vector4 clip = mPanel.finalClipRegion;
                float extents = clip.w * 0.5f;

                if (mPanel.clipping == UIDrawCall.Clipping.SoftClip)
                    extents -= mPanel.clipSoftness.y;

                float min = clip.y - extents - bmin.y;
                float max = bmax.y - extents - clip.y;

                float height = bmax.y - bmin.y;
                min = Mathf.Clamp01(min / height);
                max = Mathf.Clamp01(max / height);
                float sum = min + max;

                mIgnoreCallbacks = true;
                verticalScrollBar.barSize = 1f - sum;
                verticalScrollBar.value = (sum > 0.001f) ? 1f - min / sum : 0f;
                mIgnoreCallbacks = false;
            }
        }
        else if (recalculateBounds)
        {
            //mCalculatedBounds = false;
        }
    }

    public virtual void SetDragAmount(float x, float y, bool updateScrollbars)
    {
        DisableSpring();

        Bounds b = bounds;
        if (b.min.x == b.max.x || b.min.y == b.max.y) return;

        Vector4 clip = mPanel.finalClipRegion;
        clip.x = Mathf.Round(clip.x);
        clip.y = Mathf.Round(clip.y);
        clip.z = Mathf.Round(clip.z);
        clip.w = Mathf.Round(clip.w);

        float hx = clip.z * 0.5f;
        float hy = clip.w * 0.5f;
        float left = b.min.x + hx;
        float right = b.max.x - hx;
        float bottom = b.min.y + hy;
        float top = b.max.y - hy;

        if (mPanel.clipping == UIDrawCall.Clipping.SoftClip)
        {
            left -= mPanel.clipSoftness.x;
            right += mPanel.clipSoftness.x;
            bottom -= mPanel.clipSoftness.y;
            top += mPanel.clipSoftness.y;
        }

        float ox = Mathf.Lerp(left, right, x);
        float oy = Mathf.Lerp(top, bottom, y);

        ox = Mathf.Round(ox);
        oy = Mathf.Round(oy);

        if (!updateScrollbars)
        {
            Vector3 pos = mTrans.localPosition;
            if (canMoveHorizontally) pos.x += clip.x - ox;
            if (canMoveVertically) pos.y += clip.y - oy;
            mTrans.localPosition = pos;
        }

        if (canMoveHorizontally) clip.x = ox;
        if (canMoveVertically) clip.y = oy;

        Vector4 cr = mPanel.baseClipRegion;
        mPanel.clipOffset = new Vector2(clip.x - cr.x, clip.y - cr.y);

        if (updateScrollbars) UpdateScrollbars(false);
    }

    public void ResetPosition()
    {
        if (NGUITools.GetActive(this))
        {
            //mCalculatedBounds = false;
            SetDragAmount(relativePositionOnReset.x, relativePositionOnReset.y, false);
            SetDragAmount(relativePositionOnReset.x, relativePositionOnReset.y, true);
        }
    }

    void OnHorizontalBar()
    {
        if (!mIgnoreCallbacks)
        {
            float x = (horizontalScrollBar != null) ? horizontalScrollBar.value : 0f;
            float y = (verticalScrollBar != null) ? verticalScrollBar.value : 0f;
            SetDragAmount(x, y, false);
        }
    }

    void OnVerticalBar()
    {
        if (!mIgnoreCallbacks)
        {
            float x = (horizontalScrollBar != null) ? horizontalScrollBar.value : 0f;
            float y = (verticalScrollBar != null) ? verticalScrollBar.value : 0f;
            SetDragAmount(x, y, false);
        }
    }


    public virtual void MoveRelative(Vector3 relative)
    {
        mTrans.localPosition += relative;
        Vector2 co = mPanel.clipOffset;
        co.x -= relative.x;
        co.y -= relative.y;
        mPanel.clipOffset = co;
        UpdateScrollbars(false);
    }

    public void MoveAbsolute(Vector3 absolute)
    {
        Vector3 a = mTrans.InverseTransformPoint(absolute);
        Vector3 b = mTrans.InverseTransformPoint(Vector3.zero);
        MoveRelative(a - b);
    }

    public void Press(bool pressed)
    {
        if (smoothDragStart && pressed)
        {
            mDragStarted = false;
            mDragStartOffset = Vector2.zero;
        }

        if (enabled && NGUITools.GetActive(gameObject))
        {
            if (!pressed && mDragID == UICamera.currentTouchID) mDragID = -10;

            //mCalculatedBounds = false;
            mShouldMove = shouldMove;
            if (!mShouldMove) return;
            mPressed = pressed;

            if (pressed)
            {
                // Remove all momentum on press
                mMomentum = Vector3.zero;
                mScroll = 0f;

                // Disable the spring movement
                DisableSpring();

                // Remember the hit position
                mLastPos = UICamera.lastHit.point;

                // Create the plane to drag along
                mPlane = new Plane(mTrans.rotation * Vector3.back, mLastPos);

                // Ensure that we're working with whole numbers, keeping everything pixel-perfect
                Vector2 co = mPanel.clipOffset;
                co.x = Mathf.Round(co.x);
                co.y = Mathf.Round(co.y);
                mPanel.clipOffset = co;

                Vector3 v = mTrans.localPosition;
                v.x = Mathf.Round(v.x);
                v.y = Mathf.Round(v.y);
                mTrans.localPosition = v;
            }
            else
            {
                if (restrictWithinPanel && mPanel.clipping != UIDrawCall.Clipping.None && dragEffect == DragEffect.MomentumAndSpring)
                    RestrictWithinBounds(false, canMoveHorizontally, canMoveVertically);

                if (!smoothDragStart || mDragStarted)
                {
                    if (onDragFinished != null)
                        onDragFinished();
                }
            }
        }
    }

    public void Drag()
    {
        if (enabled && NGUITools.GetActive(gameObject) && mShouldMove)
        {
            if (mDragID == -10) mDragID = UICamera.currentTouchID;
            UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;

            // Prevents the drag "jump". Contributed by 'mixd' from the Tasharen forums.
            if (smoothDragStart && !mDragStarted)
            {
                mDragStarted = true;
                mDragStartOffset = UICamera.currentTouch.totalDelta;
            }

            Ray ray = smoothDragStart ?
                UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos - mDragStartOffset) :
                UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);

            float dist = 0f;

            if (mPlane.Raycast(ray, out dist))
            {
                Vector3 currentPos = ray.GetPoint(dist);
                Vector3 offset = currentPos - mLastPos;
                mLastPos = currentPos;

                if (offset.x != 0f || offset.y != 0f)
                {
                    offset = mTrans.InverseTransformDirection(offset);

                    if (movement == Movement.Horizontal)
                    {
                        offset.y = 0f;
                        offset.z = 0f;
                    }
                    else if (movement == Movement.Vertical)
                    {
                        offset.x = 0f;
                        offset.z = 0f;
                    }
                    else if (movement == Movement.Unrestricted)
                    {
                        offset.z = 0f;
                    }
                    else
                    {
                        offset.Scale((Vector3)customMovement);
                    }
                    offset = mTrans.TransformDirection(offset);
                }

                // Adjust the momentum
                mMomentum = Vector3.Lerp(mMomentum, mMomentum + offset * (0.01f * momentumAmount), 0.67f);

                // Move the scroll view
                if (!iOSDragEmulation)
                {
                    MoveAbsolute(offset);
                }
                else
                {
                    Vector3 constraint = mPanel.CalculateConstrainOffset(bounds.min, bounds.max);

                    if (constraint.magnitude > 1f)
                    {
                        MoveAbsolute(offset * 0.5f);
                        mMomentum *= 0.5f;
                    }
                    else
                    {
                        MoveAbsolute(offset);
                    }
                }

                // We want to constrain the UI to be within bounds
                if (restrictWithinPanel &&
                    mPanel.clipping != UIDrawCall.Clipping.None &&
                    dragEffect != DragEffect.MomentumAndSpring)
                {
                    RestrictWithinBounds(true, canMoveHorizontally, canMoveVertically);
                }
            }
        }
    }

    public void Scroll(float delta)
    {
        if (enabled && NGUITools.GetActive(gameObject) && scrollWheelFactor != 0f)
        {
            DisableSpring();
            mShouldMove = shouldMove;
            if (Mathf.Sign(mScroll) != Mathf.Sign(delta)) mScroll = 0f;
            mScroll += delta * scrollWheelFactor;
        }
    }

    void LateUpdate()
    {
        if (!Application.isPlaying) return;
        float delta = RealTime.deltaTime;

        // Fade the scroll bars if needed
        if (showScrollBars != ShowCondition.Always)
        {
            bool vertical = false;
            bool horizontal = false;

            if (showScrollBars != ShowCondition.WhenDragging || mDragID != -10 || mMomentum.magnitude > 0.01f)
            {
                vertical = shouldMoveVertically;
                horizontal = shouldMoveHorizontally;
            }

            if (verticalScrollBar)
            {
                float alpha = verticalScrollBar.alpha;
                alpha += vertical ? delta * 6f : -delta * 3f;
                alpha = Mathf.Clamp01(alpha);
                if (verticalScrollBar.alpha != alpha) verticalScrollBar.alpha = alpha;
            }

            if (horizontalScrollBar)
            {
                float alpha = horizontalScrollBar.alpha;
                alpha += horizontal ? delta * 6f : -delta * 3f;
                alpha = Mathf.Clamp01(alpha);
                if (horizontalScrollBar.alpha != alpha) horizontalScrollBar.alpha = alpha;
            }
        }

        // Apply momentum
        if (mShouldMove && !mPressed)
        {
            if (movement == Movement.Horizontal || movement == Movement.Unrestricted)
            {
                mMomentum -= mTrans.TransformDirection(new Vector3(mScroll * 0.05f, 0f, 0f));
            }
            else if (movement == Movement.Vertical)
            {
                mMomentum -= mTrans.TransformDirection(new Vector3(0f, mScroll * 0.05f, 0f));
            }
            else
            {
                mMomentum -= mTrans.TransformDirection(new Vector3(
                    mScroll * customMovement.x * 0.05f,
                    mScroll * customMovement.y * 0.05f, 0f));
            }

            if (mMomentum.magnitude > 0.0001f)
            {
                mScroll = NGUIMath.SpringLerp(mScroll, 0f, 20f, delta);

                // Move the scroll view
                Vector3 offset = NGUIMath.SpringDampen(ref mMomentum, 9f, delta);
                MoveAbsolute(offset);

                // Restrict the contents to be within the scroll view's bounds
                if (restrictWithinPanel && mPanel.clipping != UIDrawCall.Clipping.None)
                    RestrictWithinBounds(false, canMoveHorizontally, canMoveVertically);

                if (mMomentum.magnitude < 0.0001f && onDragFinished != null)
                    onDragFinished();

                return;
            }
            else
            {
                mScroll = 0f;
                mMomentum = Vector3.zero;
            }
        }
        else mScroll = 0f;

        // Dampen the momentum
        NGUIMath.SpringDampen(ref mMomentum, 9f, delta);
    }

#if UNITY_EDITOR

    /// <summary>
    /// Draw a visible orange outline of the bounds.
    /// </summary>

    void OnDrawGizmos()
    {
        if (mPanel != null)
        {
            Bounds b = bounds;
            Gizmos.matrix = transform.localToWorldMatrix;
            Gizmos.color = new Color(1f, 0.4f, 0f);
            Gizmos.DrawWireCube(new Vector3(b.center.x, b.center.y, b.min.z), new Vector3(b.size.x, b.size.y, 0f));
        }
    }
#endif
}
