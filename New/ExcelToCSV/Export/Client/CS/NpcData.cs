using System;
using System.Collections.Generic;
using System.Text;
public class NpcData{
	/// <summary>
	///编号
	/// <summary>
	public int id {get;private set;}
	/// <summary>
	///等级
	/// <summary>
	public int level {get;private set;}
	/// <summary>
	///建筑类型
	/// <summary>
	public int type {get;private set;}
	/// <summary>
	///前置建筑要求
	/// <summary>
	public string pre_build {get;private set;}
	/// <summary>
	///道具要求
	/// <summary>
	public string item {get;private set;}
	/// <summary>
	///粮食
	/// <summary>
	public int food {get;private set;}
	/// <summary>
	///石头
	/// <summary>
	public int stone {get;private set;}
	/// <summary>
	///木头
	/// <summary>
	public int wood {get;private set;}
}
