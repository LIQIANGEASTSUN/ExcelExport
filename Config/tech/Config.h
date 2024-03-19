#ifndef __TABLE_CONFIG_H
#define __TABLE_CONFIG_H
#include "BaseConfigEx.h"
struct table_behaviortreeT : ConfigBaseT
{
	virtual ~table_behaviortreeT()
	{
	}
	table_behaviortreeT()
	{
		FileName = "table_behaviortree.csv";
		_kf =
		{
			{"ID",{INT_FD, &ID}},
			{"EnName",{TSTR_FD, &EnName}},
			{"CnName",{TSTR_FD, &CnName}},
			{"Type",{INT_FD, &Type}},
			{"FloatValue",{FLOAT_FD, &FloatValue}},
			{"IntValue",{INT_FD, &IntValue}},
			{"BoolValue",{INT_FD, &BoolValue}},
			{"StringValue",{TSTR_FD, &StringValue}}
		};
	}
	virtual table_behaviortreeT* create()
	{
		return new table_behaviortreeT();
	}
	enum
	{
	};
	INT32 ID = 0;            //ID
	TStr EnName = "";				//英文名称
	TStr CnName = "";				//中文说明文字
	INT32 Type = 0;				//类型
	float FloatValue = 0.0f;				//float值
	INT32 IntValue = 0;				//int值
	INT32 BoolValue = 0;				//bool值
	TStr StringValue = "";				//string值
};
CreateCsvClass(table_behaviortree);

struct table_text_localizationT : ConfigBaseT
{
	virtual ~table_text_localizationT()
	{
	}
	table_text_localizationT()
	{
		FileName = "table_text_localization.csv";
		_kf =
		{
			{"ID",{INT_FD, &ID}},
			{"Key",{TSTR_FD, &Key}},
			{"CN",{TSTR_FD, &CN}},
			{"EN",{TSTR_FD, &EN}}
		};
	}
	virtual table_text_localizationT* create()
	{
		return new table_text_localizationT();
	}
	enum
	{
	};
	INT32 ID = 0;            //ID
	TStr Key = "";				//文本key
	TStr CN = "";				//Chinese
	TStr EN = "";				//English
};
CreateCsvClass(table_text_localization);

struct Terrain1T : ConfigBaseT
{
	virtual ~Terrain1T()
	{
	}
	Terrain1T()
	{
		FileName = "Terrain1.csv";
		_kf =
		{
			{"Terraiin",{INT_FD, &Terraiin}},
			{"ColCount",{INT_FD, &ColCount}},
			{"col0",{TSTR_FD, &col0}},
			{"col1",{TSTR_FD, &col1}},
			{"col2",{TSTR_FD, &col2}},
			{"col3",{TSTR_FD, &col3}},
			{"col4",{TSTR_FD, &col4}},
			{"col5",{TSTR_FD, &col5}},
			{"col6",{TSTR_FD, &col6}},
			{"col7",{TSTR_FD, &col7}},
			{"col8",{TSTR_FD, &col8}},
			{"col9",{TSTR_FD, &col9}},
			{"col10",{TSTR_FD, &col10}},
			{"col11",{TSTR_FD, &col11}},
			{"col12",{TSTR_FD, &col12}},
			{"col13",{TSTR_FD, &col13}},
			{"col14",{TSTR_FD, &col14}},
			{"col15",{TSTR_FD, &col15}},
			{"col16",{TSTR_FD, &col16}},
			{"col17",{TSTR_FD, &col17}},
			{"col18",{TSTR_FD, &col18}},
			{"col19",{TSTR_FD, &col19}}
		};
	}
	virtual Terrain1T* create()
	{
		return new Terrain1T();
	}
	enum
	{
	};
	INT32 Terraiin = 0;            //行ID
	INT32 ColCount = 0;				//列总数
	TStr col0 = "";				//行数据
	TStr col1 = "";				//行数据
	TStr col2 = "";				//行数据
	TStr col3 = "";				//行数据
	TStr col4 = "";				//行数据
	TStr col5 = "";				//行数据
	TStr col6 = "";				//行数据
	TStr col7 = "";				//行数据
	TStr col8 = "";				//行数据
	TStr col9 = "";				//行数据
	TStr col10 = "";				//行数据
	TStr col11 = "";				//行数据
	TStr col12 = "";				//行数据
	TStr col13 = "";				//行数据
	TStr col14 = "";				//行数据
	TStr col15 = "";				//行数据
	TStr col16 = "";				//行数据
	TStr col17 = "";				//行数据
	TStr col18 = "";				//行数据
	TStr col19 = "";				//行数据
};
CreateCsvClass(Terrain1);

struct Terrain6T : ConfigBaseT
{
	virtual ~Terrain6T()
	{
	}
	Terrain6T()
	{
		FileName = "Terrain6.csv";
		_kf =
		{
			{"Terraiin",{INT_FD, &Terraiin}},
			{"ColCount",{INT_FD, &ColCount}},
			{"col0",{TSTR_FD, &col0}},
			{"col1",{TSTR_FD, &col1}},
			{"col2",{TSTR_FD, &col2}},
			{"col3",{TSTR_FD, &col3}},
			{"col4",{TSTR_FD, &col4}},
			{"col5",{TSTR_FD, &col5}},
			{"col6",{TSTR_FD, &col6}},
			{"col7",{TSTR_FD, &col7}},
			{"col8",{TSTR_FD, &col8}},
			{"col9",{TSTR_FD, &col9}},
			{"col10",{TSTR_FD, &col10}},
			{"col11",{TSTR_FD, &col11}},
			{"col12",{TSTR_FD, &col12}},
			{"col13",{TSTR_FD, &col13}},
			{"col14",{TSTR_FD, &col14}},
			{"col15",{TSTR_FD, &col15}},
			{"col16",{TSTR_FD, &col16}},
			{"col17",{TSTR_FD, &col17}},
			{"col18",{TSTR_FD, &col18}},
			{"col19",{TSTR_FD, &col19}}
		};
	}
	virtual Terrain6T* create()
	{
		return new Terrain6T();
	}
	enum
	{
	};
	INT32 Terraiin = 0;            //行ID
	INT32 ColCount = 0;				//列总数
	TStr col0 = "";				//行数据
	TStr col1 = "";				//行数据
	TStr col2 = "";				//行数据
	TStr col3 = "";				//行数据
	TStr col4 = "";				//行数据
	TStr col5 = "";				//行数据
	TStr col6 = "";				//行数据
	TStr col7 = "";				//行数据
	TStr col8 = "";				//行数据
	TStr col9 = "";				//行数据
	TStr col10 = "";				//行数据
	TStr col11 = "";				//行数据
	TStr col12 = "";				//行数据
	TStr col13 = "";				//行数据
	TStr col14 = "";				//行数据
	TStr col15 = "";				//行数据
	TStr col16 = "";				//行数据
	TStr col17 = "";				//行数据
	TStr col18 = "";				//行数据
	TStr col19 = "";				//行数据
};
CreateCsvClass(Terrain6);

struct Terrain7T : ConfigBaseT
{
	virtual ~Terrain7T()
	{
	}
	Terrain7T()
	{
		FileName = "Terrain7.csv";
		_kf =
		{
			{"Terraiin",{INT_FD, &Terraiin}},
			{"ColCount",{INT_FD, &ColCount}},
			{"col0",{TSTR_FD, &col0}},
			{"col1",{TSTR_FD, &col1}},
			{"col2",{TSTR_FD, &col2}},
			{"col3",{TSTR_FD, &col3}},
			{"col4",{TSTR_FD, &col4}},
			{"col5",{TSTR_FD, &col5}},
			{"col6",{TSTR_FD, &col6}},
			{"col7",{TSTR_FD, &col7}},
			{"col8",{TSTR_FD, &col8}},
			{"col9",{TSTR_FD, &col9}},
			{"col10",{TSTR_FD, &col10}},
			{"col11",{TSTR_FD, &col11}},
			{"col12",{TSTR_FD, &col12}},
			{"col13",{TSTR_FD, &col13}},
			{"col14",{TSTR_FD, &col14}},
			{"col15",{TSTR_FD, &col15}},
			{"col16",{TSTR_FD, &col16}},
			{"col17",{TSTR_FD, &col17}},
			{"col18",{TSTR_FD, &col18}},
			{"col19",{TSTR_FD, &col19}}
		};
	}
	virtual Terrain7T* create()
	{
		return new Terrain7T();
	}
	enum
	{
	};
	INT32 Terraiin = 0;            //行ID
	INT32 ColCount = 0;				//列总数
	TStr col0 = "";				//行数据
	TStr col1 = "";				//行数据
	TStr col2 = "";				//行数据
	TStr col3 = "";				//行数据
	TStr col4 = "";				//行数据
	TStr col5 = "";				//行数据
	TStr col6 = "";				//行数据
	TStr col7 = "";				//行数据
	TStr col8 = "";				//行数据
	TStr col9 = "";				//行数据
	TStr col10 = "";				//行数据
	TStr col11 = "";				//行数据
	TStr col12 = "";				//行数据
	TStr col13 = "";				//行数据
	TStr col14 = "";				//行数据
	TStr col15 = "";				//行数据
	TStr col16 = "";				//行数据
	TStr col17 = "";				//行数据
	TStr col18 = "";				//行数据
	TStr col19 = "";				//行数据
};
CreateCsvClass(Terrain7);

#endif