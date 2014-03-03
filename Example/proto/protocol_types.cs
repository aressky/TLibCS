/**
 * Autogenerated by TData Compiler (0.0.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using TLibCS.Protocol;

namespace TLibCS.Creation
{

	public partial class login_req_s
	{
		private string _name;
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _password;
		public string password
		{
			get { return _password; }
			set { _password = value; }
		}

		private byte _age;
		public byte age
		{
			get { return _age; }
			set { _age = value; }
		}

		public void Read(TReader reader)
		{

			reader.ReadStructBegin("login_req_s");
			{
				if(reader.ReadFieldBegin("name"))
				{
					reader.Read(out this._name);
				}
				reader.ReadFieldEnd("name");
			}

			{
				if(reader.ReadFieldBegin("password"))
				{
					reader.Read(out this._password);
				}
				reader.ReadFieldEnd("password");
			}

			{
				if(reader.ReadFieldBegin("age"))
				{
					reader.Read(out this._age);
				}
				reader.ReadFieldEnd("age");
			}


			reader.ReadStructEnd("login_req_s");
		}

		public void Write(TWriter writer)
		{
		
			writer.WriteStructBegin("login_req_s");
			{
				if(writer.WriteFieldBegin("name"))
				{
					writer.Write(this._name);
				}
				writer.WriteFieldEnd("name");
			}

			{
				if(writer.WriteFieldBegin("password"))
				{
					writer.Write(this._password);
				}
				writer.WriteFieldEnd("password");
			}

			{
				if(writer.WriteFieldBegin("age"))
				{
					writer.Write(this._age);
				}
				writer.WriteFieldEnd("age");
			}


			writer.WriteStructEnd("login_req_s");
		}
	}

	public partial class login_rsp_s
	{
		private int _result; //0表示成功， 非0表示失败
		public int result
		{
			get { return _result; }
			set { _result = value; }
		}

		private ulong _session_id; //可以使用条件判断与据来规定何时出现这个元素， 合法的运算符有==, !=, &这三种。
		public ulong session_id
		{
			get { return _session_id; }
			set { _session_id = value; }
		}

		public void Read(TReader reader)
		{

			reader.ReadStructBegin("login_rsp_s");
			{
				if(reader.ReadFieldBegin("result"))
				{
					reader.Read(out this._result);
				}
				reader.ReadFieldEnd("result");
			}

			if(this.result == 0)
			{
				if(reader.ReadFieldBegin("session_id"))
				{
					reader.Read(out this._session_id);
				}
				reader.ReadFieldEnd("session_id");
			}


			reader.ReadStructEnd("login_rsp_s");
		}

		public void Write(TWriter writer)
		{
		
			writer.WriteStructBegin("login_rsp_s");
			{
				if(writer.WriteFieldBegin("result"))
				{
					writer.Write(this._result);
				}
				writer.WriteFieldEnd("result");
			}

			if(this.result == 0)
			{
				if(writer.WriteFieldBegin("session_id"))
				{
					writer.Write(this._session_id);
				}
				writer.WriteFieldEnd("session_id");
			}


			writer.WriteStructEnd("login_rsp_s");
		}
	}

	public partial class message_body_u
	{
		private login_req_s _login_req;
		public login_req_s login_req
		{
			get { return _login_req; }
			set { _login_req = value; }
		}

		private login_rsp_s _login_rsp;
		public login_rsp_s login_rsp
		{
			get { return _login_rsp; }
			set { _login_rsp = value; }
		}

		public void Read(TReader reader, message_id_e selector)
		{
			reader.ReadUnionBegin("message_body_u");
			switch(selector)
			{
			case message_id_e.E_MID_LOGIN_REQ:
				if(reader.ReadFieldBegin("login_req"))
				{
					this._login_req = new login_req_s();
					this._login_req.Read(reader);
				}
				reader.ReadFieldEnd("login_req");
				break;
			case message_id_e.E_MID_LOGIN_RSP:
				if(reader.ReadFieldBegin("login_rsp"))
				{
					this._login_rsp = new login_rsp_s();
					this._login_rsp.Read(reader);
				}
				reader.ReadFieldEnd("login_rsp");
				break;
			default:
				break;
			}
			reader.ReadUnionEnd("message_body_u");
		}

		public void Write(TWriter writer, message_id_e selector)
		{
			writer.WriteUnionBegin("message_body_u");
			switch(selector)
			{
			case message_id_e.E_MID_LOGIN_REQ:
				if(writer.WriteFieldBegin("login_req"))
				{
					this._login_req.Write(writer);
				}
				writer.WriteFieldEnd("login_req");
				break;
			case message_id_e.E_MID_LOGIN_RSP:
				if(writer.WriteFieldBegin("login_rsp"))
				{
					this._login_rsp.Write(writer);
				}
				writer.WriteFieldEnd("login_rsp");
				break;
			default:
				break;
			}
			writer.WriteUnionEnd("message_body_u");
		}
	}

//定义网络协议
	public partial class message_s
	{
		private message_id_e _mid;
		public message_id_e mid
		{
			get { return _mid; }
			set { _mid = value; }
		}

		private message_body_u _body;
		public message_body_u body
		{
			get { return _body; }
			set { _body = value; }
		}

		public void Read(TReader reader)
		{

			reader.ReadStructBegin("message_s");
			{
				if(reader.ReadFieldBegin("mid"))
				{
						int e;
						reader.Read(out e);
						this._mid = (message_id_e)e;
				}
				reader.ReadFieldEnd("mid");
			}

			{
				if(reader.ReadFieldBegin("body"))
				{
					this._body.Read(reader, this.mid				);
				}
				reader.ReadFieldEnd("body");
			}


			reader.ReadStructEnd("message_s");
		}

		public void Write(TWriter writer)
		{
		
			writer.WriteStructBegin("message_s");
			{
				if(writer.WriteFieldBegin("mid"))
				{
					writer.Write((int)this._mid);
				}
				writer.WriteFieldEnd("mid");
			}

			{
				if(writer.WriteFieldBegin("body"))
				{
					this._body.Write(writer, this.mid				);
				}
				writer.WriteFieldEnd("body");
			}


			writer.WriteStructEnd("message_s");
		}
	}


	public enum tconnd_instance_level_e
	{
		e_low = 0,
		e_high = 1,
	};

	public static partial class Constants
	{
		public const uint TONND_CONFIG_NUM = 1024		;
	}
	public static partial class Constants
	{
		public const uint IP_LENGTH = 16		;
	}
	public partial class tconnd_instance_config_s
	{
		private tconnd_instance_level_e _level;
		public tconnd_instance_level_e level
		{
			get { return _level; }
			set { _level = value; }
		}

		private string _ip;
		public string ip
		{
			get { return _ip; }
			set { _ip = value; }
		}

		private ushort _port;
		public ushort port
		{
			get { return _port; }
			set { _port = value; }
		}

		private uint _backlog;
		public uint backlog
		{
			get { return _backlog; }
			set { _backlog = value; }
		}

		private uint _epoll_size;
		public uint epoll_size
		{
			get { return _epoll_size; }
			set { _epoll_size = value; }
		}

		public void Read(TReader reader)
		{

			reader.ReadStructBegin("tconnd_instance_config_s");
			{
				if(reader.ReadFieldBegin("level"))
				{
						int e;
						reader.Read(out e);
						this._level = (tconnd_instance_level_e)e;
				}
				reader.ReadFieldEnd("level");
			}

			{
				if(reader.ReadFieldBegin("ip"))
				{
					reader.Read(out this._ip);
				}
				reader.ReadFieldEnd("ip");
			}

			{
				if(reader.ReadFieldBegin("port"))
				{
					reader.Read(out this._port);
				}
				reader.ReadFieldEnd("port");
			}

			{
				if(reader.ReadFieldBegin("backlog"))
				{
					reader.Read(out this._backlog);
				}
				reader.ReadFieldEnd("backlog");
			}

			{
				if(reader.ReadFieldBegin("epoll_size"))
				{
					reader.Read(out this._epoll_size);
				}
				reader.ReadFieldEnd("epoll_size");
			}


			reader.ReadStructEnd("tconnd_instance_config_s");
		}

		public void Write(TWriter writer)
		{
		
			writer.WriteStructBegin("tconnd_instance_config_s");
			{
				if(writer.WriteFieldBegin("level"))
				{
					writer.Write((int)this._level);
				}
				writer.WriteFieldEnd("level");
			}

			{
				if(writer.WriteFieldBegin("ip"))
				{
					writer.Write(this._ip);
				}
				writer.WriteFieldEnd("ip");
			}

			{
				if(writer.WriteFieldBegin("port"))
				{
					writer.Write(this._port);
				}
				writer.WriteFieldEnd("port");
			}

			{
				if(writer.WriteFieldBegin("backlog"))
				{
					writer.Write(this._backlog);
				}
				writer.WriteFieldEnd("backlog");
			}

			{
				if(writer.WriteFieldBegin("epoll_size"))
				{
					writer.Write(this._epoll_size);
				}
				writer.WriteFieldEnd("epoll_size");
			}


			writer.WriteStructEnd("tconnd_instance_config_s");
		}
	}

	public partial class tconnd_config_s
	{
		private string _log_config;
		public string log_config
		{
			get { return _log_config; }
			set { _log_config = value; }
		}

		private uint _instance_config_num;
		private tconnd_instance_config_s		[] _instance_config;
		public tconnd_instance_config_s		[] instance_config
		{
			get { return _instance_config; }
			set { _instance_config = value; }
		}

		public void Read(TReader reader)
		{

			reader.ReadStructBegin("tconnd_config_s");
			{
				if(reader.ReadFieldBegin("log_config"))
				{
					reader.Read(out this._log_config);
				}
				reader.ReadFieldEnd("log_config");
			}

			{
				reader.ReadVectorBegin();

				if (reader.ReadFieldBegin("instance_config_num"))
				{
					reader.Read(out this._instance_config_num);
					this._instance_config = new tconnd_instance_config_s[this._instance_config_num];
				}
				reader.ReadFieldEnd("instance_config_num");

				for(uint i = 0; i < Constants.TONND_CONFIG_NUM; ++i)
				{
					if(i == this._instance_config_num) break;

					if(reader.ReadVectorElementBegin("instance_config", i))
					{
					this._instance_config[i] = new tconnd_instance_config_s();
					this._instance_config[i].Read(reader				);
					}
					reader.ReadVectorElementEnd("instance_config", i);
				}
				reader.ReadVectorEnd();
			}


			reader.ReadStructEnd("tconnd_config_s");
		}

		public void Write(TWriter writer)
		{
		
			writer.WriteStructBegin("tconnd_config_s");
			{
				if(writer.WriteFieldBegin("log_config"))
				{
					writer.Write(this._log_config);
				}
				writer.WriteFieldEnd("log_config");
			}

			{
				writer.WriteVectorBegin();

				if (writer.WriteFieldBegin("instance_config_num"))
				{
					this._instance_config_num = (uint)this._instance_config.Length;
					writer.Write(this._instance_config_num);
				}
				writer.WriteFieldEnd("instance_config_num");

				for(uint i = 0; i < Constants.TONND_CONFIG_NUM; ++i)
				{
					if(i == this._instance_config_num) break;

					if(writer.WriteVectorElementBegin("instance_config", i))
					{
						this._instance_config[i].Write(writer				);
					}
					writer.WriteVectorElementEnd("instance_config", i);
				}
				writer.WriteVectorEnd();
			}


			writer.WriteStructEnd("tconnd_config_s");
		}
	}


	public enum item_type_e
	{
		e_crystal = 0,
		e_ectype = 1,
		e_other = 2,
	};

	public partial class item_limit_u
	{
		private uint _level;
		public uint level
		{
			get { return _level; }
			set { _level = value; }
		}

		private uint _mapid;
		public uint mapid
		{
			get { return _mapid; }
			set { _mapid = value; }
		}

		private uint _gold;
		public uint gold
		{
			get { return _gold; }
			set { _gold = value; }
		}

		public void Read(TReader reader, item_type_e selector)
		{
			reader.ReadUnionBegin("item_limit_u");
			switch(selector)
			{
			case item_type_e.e_crystal:
				if(reader.ReadFieldBegin("level"))
				{
					reader.Read(out this._level);
				}
				reader.ReadFieldEnd("level");
				break;
			case item_type_e.e_ectype:
				if(reader.ReadFieldBegin("mapid"))
				{
					reader.Read(out this._mapid);
				}
				reader.ReadFieldEnd("mapid");
				break;
			case item_type_e.e_other:
				if(reader.ReadFieldBegin("gold"))
				{
					reader.Read(out this._gold);
				}
				reader.ReadFieldEnd("gold");
				break;
			default:
				break;
			}
			reader.ReadUnionEnd("item_limit_u");
		}

		public void Write(TWriter writer, item_type_e selector)
		{
			writer.WriteUnionBegin("item_limit_u");
			switch(selector)
			{
			case item_type_e.e_crystal:
				if(writer.WriteFieldBegin("level"))
				{
					writer.Write(this._level);
				}
				writer.WriteFieldEnd("level");
				break;
			case item_type_e.e_ectype:
				if(writer.WriteFieldBegin("mapid"))
				{
					writer.Write(this._mapid);
				}
				writer.WriteFieldEnd("mapid");
				break;
			case item_type_e.e_other:
				if(writer.WriteFieldBegin("gold"))
				{
					writer.Write(this._gold);
				}
				writer.WriteFieldEnd("gold");
				break;
			default:
				break;
			}
			writer.WriteUnionEnd("item_limit_u");
		}
	}

	public static partial class Constants
	{
		public const uint ITEM_MAX_LIMIT = 10		;
	}
	public partial class item_table_s
	{
		private ulong _id;
		public ulong id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;
		public string name
		{
			get { return _name; }
			set { _name = value; }
		}

		private item_type_e _type;
		public item_type_e type
		{
			get { return _type; }
			set { _type = value; }
		}

		private uint _limit_list_num;
		private item_limit_u		[] _limit_list; //一般来说不要把union类型作为数组， 这里只是演示下union类型是可以作为数组的。
		public item_limit_u		[] limit_list
		{
			get { return _limit_list; }
			set { _limit_list = value; }
		}

		public void Read(TReader reader)
		{

			reader.ReadStructBegin("item_table_s");
			{
				if(reader.ReadFieldBegin("id"))
				{
					reader.Read(out this._id);
				}
				reader.ReadFieldEnd("id");
			}

			{
				if(reader.ReadFieldBegin("name"))
				{
					reader.Read(out this._name);
				}
				reader.ReadFieldEnd("name");
			}

			{
				if(reader.ReadFieldBegin("type"))
				{
						int e;
						reader.Read(out e);
						this._type = (item_type_e)e;
				}
				reader.ReadFieldEnd("type");
			}

			{
				reader.ReadVectorBegin();

				if (reader.ReadFieldBegin("limit_list_num"))
				{
					reader.Read(out this._limit_list_num);
					this._limit_list = new item_limit_u[this._limit_list_num];
				}
				reader.ReadFieldEnd("limit_list_num");

				for(uint i = 0; i < Constants.ITEM_MAX_LIMIT; ++i)
				{
					if(i == this._limit_list_num) break;

					if(reader.ReadVectorElementBegin("limit_list", i))
					{
					this._limit_list[i] = new item_limit_u();
					this._limit_list[i].Read(reader, this.type				);
					}
					reader.ReadVectorElementEnd("limit_list", i);
				}
				reader.ReadVectorEnd();
			}


			reader.ReadStructEnd("item_table_s");
		}

		public void Write(TWriter writer)
		{
		
			writer.WriteStructBegin("item_table_s");
			{
				if(writer.WriteFieldBegin("id"))
				{
					writer.Write(this._id);
				}
				writer.WriteFieldEnd("id");
			}

			{
				if(writer.WriteFieldBegin("name"))
				{
					writer.Write(this._name);
				}
				writer.WriteFieldEnd("name");
			}

			{
				if(writer.WriteFieldBegin("type"))
				{
					writer.Write((int)this._type);
				}
				writer.WriteFieldEnd("type");
			}

			{
				writer.WriteVectorBegin();

				if (writer.WriteFieldBegin("limit_list_num"))
				{
					this._limit_list_num = (uint)this._limit_list.Length;
					writer.Write(this._limit_list_num);
				}
				writer.WriteFieldEnd("limit_list_num");

				for(uint i = 0; i < Constants.ITEM_MAX_LIMIT; ++i)
				{
					if(i == this._limit_list_num) break;

					if(writer.WriteVectorElementBegin("limit_list", i))
					{
						this._limit_list[i].Write(writer, this.type				);
					}
					writer.WriteVectorElementEnd("limit_list", i);
				}
				writer.WriteVectorEnd();
			}


			writer.WriteStructEnd("item_table_s");
		}
	}

}

