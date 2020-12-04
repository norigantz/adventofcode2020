// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
public class EntryPoint__Main {
	public static void Main() {
		global::cs.Boot.init();
		global::Main.main();
	}
}

public class Main : global::haxe.lang.HxObject {
	
	public Main(global::haxe.lang.EmptyObject empty) {
	}
	
	
	public Main() {
		global::Main.__hx_ctor__Main(this);
	}
	
	
	protected static void __hx_ctor__Main(global::Main __hx_this) {
	}
	
	
	public static void main() {
		global::Main.solveDay(global::Sys.args()[0]);
	}
	
	
	public static void solveDay(string arg) {
		while ( ! (global::Main.runDaySolver(arg)) ) {
			global::System.Console.WriteLine(((object) ("No day found. Input a solved day: ") ));
			arg = ((global::haxe.io.Input) (new global::cs.io.NativeInput(((global::System.IO.Stream) (global::System.Console.OpenStandardInput()) ))) ).readLine();
		}
		
	}
	
	
	public static bool runDaySolver(string day) {
		switch (day) {
			case "1":
			{
				global::solutions.Day1.solve();
				break;
			}
			
			
			case "2":
			{
				global::solutions.Day2.solve();
				break;
			}
			
			
			case "3":
			{
				global::solutions.Day3.solve();
				break;
			}
			
			
			case "4":
			{
				global::solutions.Day4.solve();
				break;
			}
			
			
			default:
			{
				return false;
			}
			
		}
		
		return true;
	}
	
	
}


