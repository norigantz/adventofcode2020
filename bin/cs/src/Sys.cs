// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
public class Sys : global::haxe.lang.HxObject {
	
	public Sys(global::haxe.lang.EmptyObject empty) {
	}
	
	
	public Sys() {
		global::Sys.__hx_ctor__Sys(this);
	}
	
	
	protected static void __hx_ctor__Sys(global::Sys __hx_this) {
	}
	
	
	public static global::Array<string> _args;
	
	public static global::Array<string> args() {
		if (( global::Sys._args == null )) {
			global::Array<string> ret = new global::Array<string>(((string[]) (global::System.Environment.GetCommandLineArgs()) ));
			string __temp_expr1 = global::haxe.lang.Runtime.toString((ret.shift()).toDynamic());
			global::Sys._args = ret;
		}
		
		return global::Sys._args.copy();
	}
	
	
	public static readonly long epochTicks = new global::System.DateTime(1970, 1, 1).Ticks;
	
	public static double time() {
		return ( ((double) (((long) (( ((long) (global::System.DateTime.UtcNow.Ticks) ) - ((long) (global::Sys.epochTicks) ) )) )) ) / ((double) (global::System.TimeSpan.TicksPerSecond) ) );
	}
	
	
}


