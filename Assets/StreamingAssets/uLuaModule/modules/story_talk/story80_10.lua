﻿-- { "talk"--, 1, "朽木露琪亚", "又有虚了，一护，走！", 1 },
-- talk, 显示方式1左 2右 3中， "朽木露琪亚"--显示名字， "又有虚了，一护，走！"---对话内容， 1 --模型ID
--{ "destroytalk"}, --结束删除动画
--before --开始前
--after -- 结束后
local action_lists = {
    before = {
		{ "talk", 2, TextMap.GetValue("Text_1_1275"), TextMap.GetValue("Text_1_2512"), 74, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1102"), TextMap.GetValue("Text_1_2513"), 132, ""},	
		{ "talk", 2, TextMap.GetValue("Text_1_1275"), TextMap.GetValue("Text_1_2514"), 74, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1102"), TextMap.GetValue("Text_1_2515"), 132, ""},	
		{ "talk", 2, TextMap.GetValue("Text_1_1275"), TextMap.GetValue("Text_1_2516"), 74, ""},	

        { "destroytalk"},
    },

    after = {
		{ "talk", 1, TextMap.GetValue("Text_1_1183"), TextMap.GetValue("Text_1_2517"), 60, ""},	
		{ "talk", 2, TextMap.GetValue("Text_1_1275"), TextMap.GetValue("Text_1_2518"), 74, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1275"), TextMap.GetValue("Text_1_2519"), 74, ""},	
		{ "talk", 2, TextMap.GetValue("Text_1_1275"), TextMap.GetValue("Text_1_2520"), 74, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1183"), "……", 60, ""},	

        { "destroytalk"},
    },
}

return action_lists;