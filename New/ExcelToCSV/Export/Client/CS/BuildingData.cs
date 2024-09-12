using System;
using System.Collections.Generic;
using System.Text;
public class BuildingData{
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
	/// <summary>
	///铁矿
	/// <summary>
	public int iron {get;private set;}
	/// <summary>
	///时长s
	/// <summary>
	public int time {get;private set;}
	/// <summary>
	///战斗力
	/// <summary>
	public int power {get;private set;}
	/// <summary>
	///英雄经验
	/// <summary>
	public int exp {get;private set;}
	/// <summary>
	///数量
	/// <summary>
	public int num {get;private set;}
	/// <summary>
	///拆除时长s
	/// <summary>
	public int destroy_time {get;private set;}
	/// <summary>
	///建筑效果1
	/// <summary>
	public string para1 {get;private set;}
	/// <summary>
	///建筑效果2
	/// <summary>
	public string para2 {get;private set;}
	/// <summary>
	///建筑效果3
	/// <summary>
	public string para3 {get;private set;}
	/// <summary>
	///建筑效果4
	/// <summary>
	public string para4 {get;private set;}
	/// <summary>
	///建筑效果5
	/// <summary>
	public string para5 {get;private set;}
	/// <summary>
	///建筑效果6
	/// <summary>
	public string para6 {get;private set;}
	/// <summary>
	///额外效果
	/// <summary>
	public string para_extra {get;private set;}
	/// <summary>
	///建筑物升级奖励
	/// <summary>
	public int reward {get;private set;}
}
