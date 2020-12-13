// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day13 : global::haxe.lang.HxObject {
		
		static Day13() {
			global::solutions.Day13.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day13.txt");
		}
		
		
		public Day13(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day13() {
			global::solutions.Day13.__hx_ctor_solutions_Day13(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day13(global::solutions.Day13 __hx_this) {
		}
		
		
		public static string input;
		
		public static void solve() {
			unchecked {
				global::System.Console.WriteLine(((object) ("Solving Day13") ));
				global::Array<string> arr = global::haxe.lang.StringExt.split(global::solutions.Day13.input, "\r\n");
				global::haxe.lang.Null<int> arrivalAtStationTime = global::Std.parseInt(arr[0]);
				global::Array<string> _this = global::haxe.lang.StringExt.split(arr[1], ",");
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
				
				global::Array<object> busIds = ret;
				int nextBusId = 0;
				int nextBusTime = 999999999;
				{
					int _g2 = 0;
					while (( _g2 < busIds.length )) {
						global::haxe.lang.Null<int> busId = global::haxe.lang.Null<object>.ofDynamic<int>(busIds[_g2]);
						 ++ _g2;
						if ( ! (busId.hasValue) ) {
							continue;
						}
						
						int trips = ( (arrivalAtStationTime).@value / (busId).@value );
						if (( ( ( trips * (busId).@value ) + (busId).@value ) < nextBusTime )) {
							nextBusTime = ( ( trips * (busId).@value ) + (busId).@value );
							nextBusId = (busId).@value;
						}
						
					}
					
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(( nextBusId * (( nextBusTime - (arrivalAtStationTime).@value )) )))) ));
				global::Array<int> busInts = new global::Array<int>();
				{
					int _g3 = 0;
					int _g4 = busIds.length;
					while (( _g3 < _g4 )) {
						int i1 = _g3++;
						busInts[i1] = ((int) (global::haxe.lang.Runtime.toInt(busIds[i1])) );
					}
					
				}
				
				long currTime = ((long) (busInts[0]) );
				long iterator = ((long) (busInts[0]) );
				global::Array<int> busesFound = new global::Array<int>(new int[]{((int) (global::haxe.lang.Runtime.toInt(busIds[0])) )});
				while (true) {
					currTime += iterator;
					bool allSequentialBuses = true;
					{
						int _g5 = 0;
						int _g6 = busIds.length;
						while (( _g5 < _g6 )) {
							int i2 = _g5++;
							if ((  ! (global::haxe.lang.Null<object>.ofDynamic<int>(busIds[i2]).hasValue)  || busesFound.contains(((int) (global::haxe.lang.Runtime.toInt(busIds[i2])) )) )) {
								continue;
							}
							
							if (( ( (( currTime + i2 )) % busInts[i2] ) == 0 )) {
								busesFound.push(busInts[i2]);
								iterator *= ((long) (busInts[i2]) );
							}
							else {
								allSequentialBuses = false;
							}
							
						}
						
					}
					
					if (allSequentialBuses) {
						break;
					}
					
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", global::Std.@string(currTime))) ));
			}
		}
		
		
	}
}


