// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day1 : global::haxe.lang.HxObject {
		
		static Day1() {
			global::solutions.Day1.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day1.txt");
		}
		
		
		public Day1(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day1() {
			global::solutions.Day1.__hx_ctor_solutions_Day1(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day1(global::solutions.Day1 __hx_this) {
		}
		
		
		public static string input;
		
		public static void solve() {
			global::System.Console.WriteLine(((object) ("Solving Day1") ));
			global::Array<string> _this = global::haxe.lang.StringExt.split(global::solutions.Day1.input, "\r\n");
			global::haxe.lang.Function f = ((global::haxe.lang.Function) (new global::haxe.lang.Closure(typeof(global::Std), "parseInt", 1450317436)) );
			global::Array<object> ret = new global::Array<object>(((object[]) (new object[_this.length]) ));
			{
				int _g = 0;
				int _g1 = _this.length;
				while (( _g < _g1 )) {
					int i = _g++;
					{
						global::haxe.lang.Null<int> val = global::haxe.lang.Null<object>.ofDynamic<int>(f.__hx_invoke1_o(default(double), ((string) (_this.__a[i]) )));
						ret.__a[i] = (val).toDynamic();
					}
					
				}
				
			}
			
			global::Array<int> arr = ((global::Array<int>) (global::Array<object>.__hx_cast<int>(((global::Array) (ret) ))) );
			global::solutions.Day1.solve_a(arr);
			global::solutions.Day1.solve_b(arr);
		}
		
		
		public static void solve_a(global::Array<int> arr) {
			unchecked {
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(global::solutions.Day1.multSum(arr, 2020)))) ));
			}
		}
		
		
		public static void solve_b(global::Array<int> arr) {
			unchecked {
				int curr = 0;
				int res = -1;
				{
					int _g = 0;
					while (( _g < arr.length )) {
						int a = arr[_g];
						 ++ _g;
						curr = a;
						res = global::solutions.Day1.multSum(arr, ( 2020 - curr ));
						if (( res > -1 )) {
							break;
						}
						
					}
					
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", global::haxe.lang.Runtime.toString(( curr * res )))) ));
			}
		}
		
		
		public static int multSum(global::Array<int> arr, int sumTarget) {
			unchecked {
				{
					int _g = 0;
					int _g1 = arr.length;
					while (( _g < _g1 )) {
						int i = _g++;
						{
							int _g2 = i;
							int _g3 = arr.length;
							while (( _g2 < _g3 )) {
								int j = _g2++;
								if (( arr[j] == ( sumTarget - arr[i] ) )) {
									return ( arr[i] * arr[j] );
								}
								
							}
							
						}
						
					}
					
				}
				
				return -1;
			}
		}
		
		
	}
}


