﻿-- { "talk"--, 1, "朽木露琪亚", "又有虚了，一护，走！", 1 },
-- talk, 显示方式1左 2右 3中， "朽木露琪亚"--显示名字， "又有虚了，一护，走！"---对话内容， 1 --模型ID
--{ "destroytalk"}, --结束删除动画
--before --开始前
--after -- 结束后
local action_lists = {
    before = {
		{ "talk", 2, TextMap.GetValue("Text_1_294"), TextMap.GetValue("Text_1_2526"), 9, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1261"), TextMap.GetValue("Text_1_2527"), 53, ""},	
		{ "talk", 2, TextMap.GetValue("Text_1_294"), TextMap.GetValue("Text_1_2528"), 9, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1261"), TextMap.GetValue("Text_1_2529"), 53, ""},	

        { "destroytalk"},
    },

    after = {
		{ "talk", 2, TextMap.GetValue("Text_1_1261"), TextMap.GetValue("Text_1_2530"), 53, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_294"), TextMap.GetValue("Text_1_2531"), 9, ""},	
		{ "talk", 2, TextMap.GetValue("Text_1_294"), TextMap.GetValue("Text_1_2532"), 9, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1261"), TextMap.GetValue("Text_1_2533"), 53, ""},	

        { "destroytalk"},
    },
}

return action_lists;