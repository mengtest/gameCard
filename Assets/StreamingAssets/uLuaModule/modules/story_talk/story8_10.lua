﻿-- { "talk"--, 1, "朽木露琪亚", "又有虚了，一护，走！", 1 },
-- talk, 显示方式1左 2右 3中， "朽木露琪亚"--显示名字， "又有虚了，一护，走！"---对话内容， 1 --模型ID
--{ "destroytalk"}, --结束删除动画
--before --开始前
--after -- 结束后
local action_lists = {
    before = {
		{ "talk", 2, TextMap.GetValue("Text_1_233"), TextMap.GetValue("Text_1_2642"), 23, ""},
		{ "talk", 1, TextMap.GetValue("Text_1_1110"), TextMap.GetValue("Text_1_2643"), 153, ""},
		{ "talk", 2, TextMap.GetValue("Text_1_233"), TextMap.GetValue("Text_1_2644"), 23, ""},




        { "destroytalk"},
    },

    after = {
		{ "talk", 1, TextMap.GetValue("Text_1_1110"), TextMap.GetValue("Text_1_2645"), 153, ""},
		{ "talk", 2, TextMap.GetValue("Text_1_233"), TextMap.GetValue("Text_1_2646"), 23, ""},
		{ "talk", 1, TextMap.GetValue("Text_1_1110"), TextMap.GetValue("Text_1_2647"), 153, ""},
		{ "talk", 2, TextMap.GetValue("Text_1_233"), TextMap.GetValue("Text_1_2648"), 23, ""},
    { "talk", 1, TextMap.GetValue("Text_1_1110"), TextMap.GetValue("Text_1_2649"), 153, ""},



        { "destroytalk"},
    },
}

return action_lists;