// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day2 : global::haxe.lang.HxObject {
		
		static Day2() {
			global::solutions.Day2.input = global::sys.io.File.getContent("inputs/Day2.txt");
		}
		
		
		public Day2(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day2() {
			global::solutions.Day2.__hx_ctor_solutions_Day2(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day2(global::solutions.Day2 __hx_this) {
		}
		
		
		public static string input;
		
		public static void solve() {
			unchecked {
				global::System.Console.WriteLine(((object) ("Solving Day2") ));
				global::Array<string> arr = global::haxe.lang.StringExt.split(global::solutions.Day2.input, "\r\n");
				int resultA = 0;
				int resultB = 0;
				{
					int _g = 0;
					while (( _g < arr.length )) {
						string line = arr[_g];
						 ++ _g;
						global::Array<string> lineArr = global::haxe.lang.StringExt.split(line, ":");
						string policy = lineArr[0];
						string password = lineArr[1].Trim();
						global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(policy, ", "), password)) ));
						global::Array<string> minMaxArr = global::haxe.lang.StringExt.split(policy, "-");
						global::haxe.lang.Null<int> min = global::Std.parseInt(minMaxArr[0]);
						global::haxe.lang.Null<int> max = global::Std.parseInt(global::haxe.lang.StringExt.split(minMaxArr[1], " ")[0]);
						string @char = global::haxe.lang.StringExt.split(minMaxArr[1], " ")[1];
						global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat("min: ", global::haxe.lang.Runtime.toString((min).toDynamic())), ", max: "), global::haxe.lang.Runtime.toString((max).toDynamic())), ", char: "), @char)) ));
						int count = ( global::haxe.lang.StringExt.split(password, @char).length - 1 );
						global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("count: ", global::haxe.lang.Runtime.toString(count))) ));
						if (( ( count >= (min).@value ) && ( count <= (max).@value ) )) {
							 ++ resultA;
						}
						
						if (( ( ( global::haxe.lang.Runtime.concat("", global::Std.@string(password[( (min).@value - 1 )])) == @char ) && ( global::haxe.lang.Runtime.concat("", global::Std.@string(password[( (max).@value - 1 )])) != @char ) ) || ( ( global::haxe.lang.Runtime.concat("", global::Std.@string(password[( (min).@value - 1 )])) != @char ) && ( global::haxe.lang.Runtime.concat("", global::Std.@string(password[( (max).@value - 1 )])) == @char ) ) )) {
							 ++ resultB;
						}
						
						global::System.Console.WriteLine(((object) ("") ));
					}
					
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(resultA))) ));
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", global::haxe.lang.Runtime.toString(resultB))) ));
			}
		}
		
		
	}
}


