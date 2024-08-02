
namespace F4lang.Builder.T1.Tests.Framework.Extensions;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddMockedServices(this IServiceCollection @this)
	{
		@this.AddTransient<IY_InStr_OutBool_AsyncService, Y_InStr_OutBool_AsyncService>();
		@this.AddTransient<IY_InObjBool_OutStr_AsyncService, Y_InObjBool_OutStr_AsyncService>();
		@this.AddTransient<IY_InObjBool_OutNullStr_AsyncService, Y_InObjBool_OutNullStr_AsyncService>();
		@this.AddTransient<IY_InObjBool_OutBool_AsyncService, Y_InObjBool_OutBool_AsyncService>();
		@this.AddTransient<IY_InStr_AsyncService, Y_InStr_AsyncService>();
		@this.AddTransient<IY_InStrBool_AsyncService, Y_InStrBool_AsyncService>();
		@this.AddTransient<IY_InStrBool_OutStr_AsyncService, Y_InStrBool_OutStr_AsyncService>();
		@this.AddTransient<IY_AsyncService, Y_AsyncService>();
		@this.AddSingleton<IY_InObj_OutObj_SingletonAsyncService, Y_InObj_OutObj_SingletonAsyncService>();
		@this.AddTransient<IY_InObjObj_OutObj_AsyncService, Y_InObjObj_OutObj_AsyncService>();
		@this.AddTransient<IY_SyncService, Y_SyncService>();
		@this.AddTransient<IY_OutConstBool_SyncService, Y_OutConstBool_SyncService>();
		@this.AddTransient<IY_InInt_OutBool_SyncService, Y_InInt_OutBool_SyncService>();
		@this.AddTransient<IY_InStr_OutInt_AsyncService, Y_InStr_OutInt_AsyncService>();
		@this.AddTransient<IY_InStr_OutConstInt_AsyncService, Y_InStr_OutConstInt_AsyncService>();
		@this.AddTransient<IY_InInt_OutConstInt_AsyncService, Y_InInt_OutConstInt_AsyncService>();
		@this.AddTransient<IY_InBoolStr_OutConstInt_AsyncService, Y_InBoolStr_OutConstInt_AsyncService>();
		@this.AddTransient<IY_OutConstFalseBool_SyncService, Y_OutConstFalseBool_SyncService>();
		@this.AddTransient<IY_InStr_OutConstStr_AsyncService, Y_InStr_OutConstStr_AsyncService>();
		@this.AddTransient<IY_InBool_OutConstStrIfFalseElseDynamicStr_AsyncService, Y_InBool_OutConstStrIfFalseElseDynamicStr_AsyncService>();
		@this.AddTransient<IY_InBool_OutConstStr_AsyncService, Y_InBool_OutConstStr_AsyncService>();
		@this.AddTransient<IY_InStrStrStr_OutConstInt_AsyncService, Y_InStrStrStr_OutConstInt_AsyncService>();
		@this.AddTransient<IY_OutObj_SyncService, Y_OutObj_SyncService>();
		@this.AddTransient<IY_InObj_OutConstInt_AsyncService, Y_InObj_OutConstInt_AsyncService>();
		@this.AddTransient<IY_OutBool_ConfigurableSyncService, Y_OutBool_ConfigurableSyncService>();

		return @this;
	}

	public static IServiceCollection AddTestServices(this IServiceCollection @this)
	{
		@this.AddSingleton<ILogOutput, LogOutput>();
		return @this;
	}
}
