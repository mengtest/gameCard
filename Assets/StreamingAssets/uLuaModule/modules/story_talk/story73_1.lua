﻿-- { "talk"--, 1, "朽木露琪亚", "又有虚了，一护，走！", 1 },
-- talk, 显示方式1左 2右 3中， "朽木露琪亚"--显示名字， "又有虚了，一护，走！"---对话内容， 1 --模型ID
--{ "destroytalk"}, --结束删除动画
--before --开始前
--after -- 结束后
local action_lists = {
    before = {
		{ "talk", 2, TextMap.GetValue("Text_1_227"), TextMap.GetValue("Text_1_2407"), 2, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1175"), TextMap.GetValue("Text_1_2408"), 46, ""},	
		{ "talk", 2, "player", TextMap.GetValue("Text_1_2409"), -1, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1183"), TextMap.GetValue("Text_1_2410"), 60, ""},	
		{ "talk", 2, "player", TextMap.GetValue("Text_1_2411"), -1, ""},	
		{ "talk", 1, TextMap.GetValue("Text_1_1183"), TextMap.GetValue("Text_1_2412"), 60, ""},	

        { "destroytalk"},
    },

    
}

return action_lists;