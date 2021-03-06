// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day15 : global::haxe.lang.HxObject {
		
		static Day15() {
			unchecked{
				global::solutions.Day15.input = new global::Array<int>(new int[]{0, 3, 1, 6, 7, 5});
				global::solutions.Day15.inputEx1 = new global::Array<int>(new int[]{0, 3, 6});
			}
		}
		
		
		public Day15(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day15() {
			global::solutions.Day15.__hx_ctor_solutions_Day15(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day15(global::solutions.Day15 __hx_this) {
		}
		
		
		public static global::Array<int> input;
		
		public static global::Array<int> inputEx1;
		
		public static void solve() {
			unchecked {
				global::System.Console.WriteLine(((object) ("Solving Day15") ));
				global::Array<int> arr = global::solutions.Day15.input;
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(global::solutions.Day15.runGameFast(arr, 2020)))) ));
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", global::haxe.lang.Runtime.toString(global::solutions.Day15.runGameFast(arr, 30000000)))) ));
			}
		}
		
		
		public static int runGameFast(global::Array<int> arr, int loops) {
			unchecked {
				global::Array<object> numAges = new global::Array<object>();
				numAges.resize(loops);
				int numCount = 0;
				int lastNumber = arr[0];
				while (( numCount < ( loops - 1 ) )) {
					if (( numCount < arr.length )) {
						numAges[lastNumber] = ((object) (numCount) );
						 ++ numCount;
						lastNumber = arr[numCount];
					}
					else if ( ! (global::haxe.lang.Null<object>.ofDynamic<int>(numAges[lastNumber]).hasValue) ) {
						numAges[lastNumber] = ((object) (numCount) );
						 ++ numCount;
						lastNumber = 0;
					}
					else {
						int diff = ( numCount - (global::haxe.lang.Null<object>.ofDynamic<int>(numAges[lastNumber])).@value );
						numAges[lastNumber] = ((object) (numCount) );
						 ++ numCount;
						lastNumber = diff;
					}
					
				}
				
				return lastNumber;
			}
		}
		
		
	}
}


