﻿-- { "talk"--, 1, "朽木露琪亚", "又有虚了，一护，走！", 1 },
-- talk, 显示方式1左 2右 3中， "朽木露琪亚"--显示名字， "又有虚了，一护，走！"---对话内容， 1 --模型ID
--{ "destroytalk"}, --结束删除动画
--before --开始前
--after -- 结束后
local action_lists = {
    before = {
		{ "talk", 1, TextMap.GetValue("Text_1_227"), TextMap.GetValue("Text_1_2301"), 2, ""},	
		{ "talk", 2, "player", TextMap.GetValue("Text_1_2302"), -1, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_227"), TextMap.GetValue("Text_1_2303"), 2, ""},	
		{ "talk", 2, "player", TextMap.GetValue("Text_1_2304"), -1, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_227"), "^(*￣(oo)￣)^不对不对！飞鸟是我，是我啦！！", 2, ""},	

        { "destroytalk"},
    },

    after = {
		{ "talk", 2, "player", TextMap.GetValue("Text_1_2305"), -1, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_227"), TextMap.GetValue("Text_1_2306"), 2, ""},	
		{ "talk", 2, "player", TextMap.GetValue("Text_1_2307"), -1, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_227"), "……O__O…", 2, ""},	

        { "destroytalk"},
    },
}

return action_lists;