﻿// The MIT License (MIT)

// Copyright 2015 Siney/Pangweiwei siney@yeah.net
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace SLua
{
	using System.Collections.Generic;
	using System;

	public class CustomExport
	{

		public static void OnAddCustomClass(LuaCodeGen.ExportGenericDelegate add)
		{
			add(typeof(System.Func<int>), null);
			add(typeof(System.Action<int, string>), null);
			add(typeof(System.Action<int, Dictionary<int, object>>), null);
			add(typeof(List<int>), "ListInt");
			add(typeof(Dictionary<int, string>), "DictIntStr");
			add(typeof(string), "String");
            ExportMyClass.OnAddCustomClass(add);
            // add your custom class here
            // add( type, typename)
            // type is what you want to export
            // typename used for simplify generic type name or rename, like List<int> named to "ListInt", if not a generic type keep typename as null or rename as new type name
        }

		public static void OnAddCustomAssembly(ref List<string> list)
		{
            // add your custom assembly here
            // you can build a dll for 3rd library like ngui titled assembly name "NGUI", put it in Assets folder
            // add it's name into list, slua will generate all exported interface automatically for you

            list.Add("NGUI");
        }

        public static HashSet<string> OnAddCustomNamespace()
        {
            return new HashSet<string>
            {
                //"NLuaTest.Mock"
            };
        }

        // if uselist return a white list, don't check noUseList(black list) again
        public static void OnGetUseList(out List<string> list)
        {
            list = new List<string>
            {
                //"UnityEngine.GameObject",
            };
        }

        public static List<string> FunctionFilterList = new List<string>()
        {
            "UIWidget.showHandles",
            "UIWidget.showHandlesWithMoveTool",
        };
        // black list if white list not given
        public static void OnGetNoUseList(out List<string> list)
        {
            list = new List<string>
        {      
            "HideInInspector",
            "ExecuteInEditMode",
            "AddComponentMenu",
            "ContextMenu",
            "RequireComponent",
            "DisallowMultipleComponent",
            "SerializeField",
            "AssemblyIsEditorAssembly",
            "Attribute", 
            "Types",
            "UnitySurrogateSelector",
            "TrackedReference",
            "TypeInferenceRules",
            "FFTWindow",
            "RPC",
            "Network",
            "MasterServer",
            "BitStream",
            "HostData",
            "ConnectionTesterStatus",
            "GUI",
            "EventType",
            "EventModifiers",
            "FontStyle",
            "TextAlignment",
            "TextEditor",
            "TextEditorDblClickSnapping",
            "TextGenerator",
            "TextClipping",
            "Gizmos",
             "ADBannerView",
            "ADInterstitialAd",            
            "Android",
			"Tizen",
            "jvalue",
            "iPhone",
            "iOS",
            "CalendarIdentifier",
            "CalendarUnit",
            "CalendarUnit",
            "FullScreenMovieControlMode",
            "FullScreenMovieScalingMode",
            "Handheld",
            "LocalNotification",
            "NotificationServices",
            "RemoteNotificationType",      
            "RemoteNotification",
            "SamsungTV",
            "TextureCompressionQuality",
            "TouchScreenKeyboardType",
            "TouchScreenKeyboard",
            "MovieTexture",
            "UnityEngineInternal",
            "Terrain",                            
            "Tree",
            "SplatPrototype",
            "DetailPrototype",
            "DetailRenderMode",
            "MeshSubsetCombineUtility",
            "AOT",
            "Social",
            "Enumerator",       
            "SendMouseEvents",               
            "Cursor",
            "Flash",
            "ActionScript",
            "OnRequestRebuild",
			"Ping",
            "ShaderVariantCollection",
			"SimpleJson.Reflection",
			"CoroutineTween",
			"GraphicRebuildTracker",
            "Advertisements",
            "UnityEditor",
            "ClusterInput",
                "SkeletonBone",
                "HumanLimit",
                "HumanBone",
                "HumanDescription",
                "AvatarBuilder",
                "HumanBodyBones",
                "Avatar",
                "HumanTrait",
                "HumanPose",
                "HumanPoseHandler",
                "Experimental_Director_AnimationPlayable",
                "Experimental_Director_AnimationMixerPlayable",
                "Experimental_Director_AnimationClipPlayable",
                "Experimental_Director_AnimatorControllerPlayable",
                "TextGenerationSettings",
                "TextAnchor",
                "HorizontalWrapMode",
                "VerticalWrapMode",
                "TextMesh",
                "CharacterInfo",
                "Font",
                "UICharInfo",
                "UILineInfo",
                "UIVertex",
                "VR",
                "RenderBuffer",
                "RenderTargetSetup",
                "RenderingPath",
                "Rendering",
                "Annotations",
                "RuntimeInitializeLoadType",
                "StackTraceUtility",
                "UnityException",
                "MissingComponentException",
                "UnassignedReferenceException",
                "MissingReferenceException",
                "StateMachineBehaviour",
                "StackTraceLogType",
                "WindZoneMode",
                "WindZone",
                "DynamicGI",
                "ParticleSystemRenderMode",
                "ParticleSystemSortMode",
                "ParticleSystemCollisionQuality",
                "ParticleSystemRenderSpace",
                "ParticleSystemEmissionType",
                "ParticleSystemCurveMode",
                "ParticleSystemGradientMode",
                "ParticleSystemShapeType",
                "ParticleSystemMeshShapeType",
                "ParticleSystemAnimationType",
                "ParticleSystemCollisionType",
                "ParticleSystemCollisionMode",
                "ParticleSystemSimulationSpace",
                "ParticleSystemScalingMode",
                "ParticleSystemInheritVelocityMode",
                "ParticleSystem",
                "ParticleSystem_Burst",
                "ParticleSystem_MinMaxCurve",
                "ParticleSystem_MinMaxGradient",
                "ParticleSystem_EmissionModule",
                "ParticleSystem_ShapeModule",
                "ParticleSystem_VelocityOverLifetimeModule",
                "ParticleSystem_LimitVelocityOverLifetimeModule",
                "ParticleSystem_InheritVelocityModule",
                "ParticleSystem_ForceOverLifetimeModule",
                "ParticleSystem_ColorOverLifetimeModule",
                "ParticleSystem_ColorBySpeedModule",
                "ParticleSystem_SizeOverLifetimeModule",
                "ParticleSystem_SizeBySpeedModule",
                "ParticleSystem_RotationOverLifetimeModule",
                "ParticleSystem_RotationBySpeedModule",
                "ParticleSystem_ExternalForcesModule",
                "ParticleSystem_CollisionModule",
                "ParticleSystem_SubEmittersModule",
                "ParticleSystem_TextureSheetAnimationModule",
                "ParticleSystem_Particle",
                "ParticleSystem_EmitParams",
                "ParticleSystemRenderer",
                "ParticleCollisionEvent",
                "ParticlePhysicsExtensions",
                "Particle",
                "ParticleEmitter",
                "EllipsoidParticleEmitter",
                "MeshParticleEmitter",
                "ParticleAnimator",
                "ParticleRenderMode",
                "ParticleRenderer",
                "RigidbodyConstraints",
                "ForceMode",
                "JointProjectionMode",
                "WheelFrictionCurve",
                "SoftJointLimit",
                "SoftJointLimitSpring",
                "JointDrive",
                "RigidbodyInterpolation",
                "JointMotor",
                "JointSpring",
                "JointLimits",
                "ControllerColliderHit",
                "PhysicMaterialCombine",
                "Physics2D",
                "RaycastHit2D",
                "RigidbodyInterpolation2D",
                "RigidbodySleepMode2D",
                "CollisionDetectionMode2D",
                "ForceMode2D",
                "RigidbodyConstraints2D",
                "Rigidbody2D",
                "Collider2D",
                "CircleCollider2D",
                "BoxCollider2D",
                "EdgeCollider2D",
                "PolygonCollider2D",
                "ContactPoint2D",
                "Collision2D",
                "JointLimitState2D",
                "JointAngleLimits2D",
                "JointTranslationLimits2D",
                "JointMotor2D",
                "JointSuspension2D",
                "Joint2D",
                "AnchoredJoint2D",
                "SpringJoint2D",
                "DistanceJoint2D",
                "FrictionJoint2D",
                "HingeJoint2D",
                "RelativeJoint2D",
                "SliderJoint2D",
                "TargetJoint2D",
                "FixedJoint2D",
                "WheelJoint2D",
                "PhysicsMaterial2D",
                "PhysicsUpdateBehaviour2D",
                "ConstantForce2D",
                "EffectorSelection2D",
                "EffectorForceMode2D",
                "Effector2D",
                "AreaEffector2D",
                "BuoyancyEffector2D",
                "PointEffector2D",
                "PlatformEffector2D",
                "SurfaceEffector2D",
                "ObstacleAvoidanceType",
                "NavMeshAgent",
                "NavMeshHit",
                "NavMeshTriangulation",
                "NavMesh",
                "NavMeshObstacleShape",
                "NavMeshObstacle",
                "NavMeshPathStatus",
                "NavMeshPath",
                "OffMeshLinkType",
                "OffMeshLinkData",
                "OffMeshLink",
                "Microphone",
                "WebCamFlags",
                "WebCamDevice",
                "WebCamTexture",
                "AsyncOperation",
                "PrimitiveType",
                "ScriptableObject",
                "ThreadPriority",
                "Profiler",
                "Caching",
                "CrashReport",
                "OcclusionArea",
                "OcclusionPortal",
                "CombineInstance",
                "BoneWeight",
                "SkinnedMeshRenderer",
                "Flare",
                "LensFlare",
                "Projector",
                "TrailRenderer",
                "MaterialPropertyBlock",
                "Graphics",
                "GeometryUtility",
                "GL",
                "StaticBatchingUtility",
                "ImageEffectTransformsToLDR",
                "ImageEffectOpaque",
                "ReflectionProbe",
                "LODFadeMode",
                "LOD",
                "LODGroup",
                "BoundingSphere",
                "CullingGroupEvent",
                "CullingGroup",
                "GradientColorKey",
                "GradientAlphaKey",
                "Gradient",
                "LightProbeGroup",
                "DrivenTransformProperties",
                "DrivenRectTransformTracker",
                "ProceduralProcessorUsage",
                "ProceduralCacheSize",
                "ProceduralLoadingBehavior",
                "ProceduralPropertyType",
                "ProceduralOutputType",
                "ProceduralPropertyDescription",
                "ProceduralMaterial",
                "ProceduralTexture",
                "SpriteAlignment",
                "SpritePackingMode",
                "SpritePackingRotation",
                "SpriteMeshType",
                "Sprite",
                "SpriteRenderer",
                "DataUtility",
                "Hash128",
                "UserAuthorization",
                "ApplicationInstallMode",
                "ApplicationSandboxType",
                "IMECompositionMode",
                "DeviceOrientation",
                "AccelerationEvent",
                "Gyroscope",
                "LocationInfo",
                "LocationServiceStatus",
                "LocationService",
                "HideFlags",
                "Motion",
                "BillboardAsset",
                "BillboardRenderer",
                "Experimental",
                "ClothSkinningCoefficient",
                "QueryTriggerInteraction",
                "WheelHit",
                "ContactPoint",
                "Joint",
                "HingeJoint",
                "SpringJoint",
                "FixedJoint",
                "CharacterJoint",
                "ConfigurableJointMotion",
                "RotationDriveMode",
                "ConfigurableJoint",
                "ConstantForce",
                "CollisionDetectionMode",
                "WheelCollider",
                "CharacterController",
                "ClothSphereColliderPair",
                "Cloth",
                "MatchTargetWeightMask",
                "RenderMode",
                "FocusType",
                "TransparencySortMode",
                "ComputeBufferType",
                "ShadowProjection",
                "CameraClearFlags",
                "DepthTextureMode",
                "TexGenMode",
                "AnisotropicFiltering",
                "BlendWeights",
                "MeshTopology",
                "SkinQuality",
                "ColorSpace",
                "ScreenOrientation",
                "FilterMode",
                "TextureWrapMode",
                "NPOTSupport",
                "CubemapFace",
                "RenderTextureFormat",
                "RenderTextureReadWrite",
                "MaterialGlobalIlluminationFlags",
                "Assertions",
				"TV"
        };
		}

	}
}
