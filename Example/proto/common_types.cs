/**
 * Autogenerated by TData Compiler (0.0.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */

using System;
using TLibCS.Protocol;

namespace TLibCS.Creation
{


	public enum message_id_e
	{
		E_MID_LOGIN_REQ = 0,
		E_MID_LOGIN_RSP = 1,
	};

//��MESSAGE_ID_NUM����¼ö������message_id_e�еĳ�Ա����, count�������Զ�struct, union, enum����������ʹ��
	public static partial class Constants
	{
		public const uint MESSAGE_ID_NUM = 2		;
	}
	public static partial class Constants
	{
		public const string VERSION = "0.0.1"		;
	}
	public static partial class Constants
	{
		public const uint MAX_NAME_LENGTH = 255		;
	}
}
