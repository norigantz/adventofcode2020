// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day14 : global::haxe.lang.HxObject {
		
		static Day14() {
			global::solutions.Day14.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day14.txt");
			global::solutions.Day14.arr = global::haxe.lang.StringExt.split(global::solutions.Day14.input, "\r\n");
			global::solutions.Day14.memory = new global::haxe.ds.StringMap<long>();
		}
		
		
		public Day14(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day14() {
			global::solutions.Day14.__hx_ctor_solutions_Day14(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day14(global::solutions.Day14 __hx_this) {
		}
		
		
		public static string input;
		
		public static global::Array<string> arr;
		
		public static global::haxe.ds.StringMap<long> memory;
		
		public static void solve() {
			global::System.Console.WriteLine(((object) ("Solving Day14") ));
			global::solutions.Day14.decoderV1();
			((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (((global::haxe.IMap<string, long>) (global::solutions.Day14.memory) )) ))) ).clear();
			global::solutions.Day14.decoderV2();
		}
		
		
		public static void decoderV2() {
			unchecked {
				string mask = "";
				{
					int _g = 0;
					global::Array<string> _g1 = global::solutions.Day14.arr;
					while (( _g < _g1.length )) {
						string line = _g1[_g];
						 ++ _g;
						global::Array<string> lineArr = global::haxe.lang.StringExt.split(line, "=");
						string instruct = lineArr[0].TrimEnd();
						if (( instruct == "mask" )) {
							mask = lineArr[1].TrimStart();
						}
						else if (( global::haxe.lang.StringExt.substr(instruct, 0, new global::haxe.lang.Null<int>(3, true)) == "mem" )) {
							string addr = global::haxe.lang.StringExt.split(instruct, "[")[1];
							int parsedAddress = ((int) (((double) ((global::Std.parseInt(global::haxe.lang.StringExt.substr(addr, 0, new global::haxe.lang.Null<int>(( addr.Length - 1 ), true)))).@value) )) );
							global::Array<string> writeAddresses = global::solutions.Day14.applyMaskToAddress(mask, parsedAddress);
							{
								int _g2 = 0;
								while (( _g2 < writeAddresses.length )) {
									string address = writeAddresses[_g2];
									 ++ _g2;
									{
										global::haxe.IMap<string, long> this1 = global::solutions.Day14.memory;
										long v = ((long) ((global::Std.parseInt(lineArr[1].TrimStart())).@value) );
										((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (this1) ))) ).@set(address, v);
									}
									
								}
								
							}
							
						}
						
					}
					
				}
				
				long sum = ((long) (0) );
				{
					object key = ((object) (new global::haxe.ds._StringMap.StringMapKeyIterator<long>(((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (((global::haxe.IMap<string, long>) (global::solutions.Day14.memory) )) ))) ))) );
					while (global::haxe.lang.Runtime.toBool(global::haxe.lang.Runtime.callField(key, "hasNext", 407283053, null))) {
						string key1 = global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.callField(key, "next", 1224901875, null));
						sum = ( ((long) (sum) ) + (((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (((global::haxe.IMap<string, long>) (global::solutions.Day14.memory) )) ))) ).@get(key1)).@value );
					}
					
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", (global::haxe.lang.Runtime.concat("", global::Std.@string(((long) (sum) )))))) ));
			}
		}
		
		
		public static global::Array<string> applyMaskToAddress(string mask, int address) {
			unchecked {
				long initialOutputAddress = ((long) (address) );
				global::Array<int> floatingBits = new global::Array<int>();
				int currBit = 0;
				long one = ((long) (1) );
				while (( currBit < mask.Length )) {
					switch (global::haxe.lang.StringExt.charAt(mask, ( ( mask.Length - 1 ) - currBit ))) {
						case "0":
						{
							break;
						}
						
						
						case "1":
						{
							initialOutputAddress = ((long) (( ((long) (initialOutputAddress) ) | ((long) (( ((long) (one) ) << currBit )) ) )) );
							break;
						}
						
						
						case "X":
						{
							floatingBits.push(currBit);
							break;
						}
						
						
						default:
						{
							global::System.Console.WriteLine(((object) ("Unhandled bitmask character in applyMask()") ));
							break;
						}
						
					}
					
					 ++ currBit;
				}
				
				global::Array<string> writeAddresses = new global::Array<string>();
				long newAddress = default(long);
				long floatingMask = ((long) (0) );
				while (( ((long) (floatingMask) ) < ((long) (global::System.Math.Pow(((double) (2) ), ((double) (floatingBits.length) ))) ) )) {
					newAddress = initialOutputAddress;
					{
						int _g = 0;
						int _g1 = floatingBits.length;
						while (( _g < _g1 )) {
							int i = _g++;
							if (( (((long) (( ((long) (floatingMask) ) & ((long) (( ((long) (one) ) << i )) ) )) )) > ((long) (0) ) )) {
								newAddress = ((long) (( ((long) (newAddress) ) | ((long) (( ((long) (one) ) << floatingBits[i] )) ) )) );
							}
							else {
								newAddress = ((long) (( ((long) (newAddress) ) & ((long) ( ~ ((((long) (( ((long) (one) ) << floatingBits[i] )) ))) ) ) )) );
							}
							
						}
						
					}
					
					writeAddresses.push(global::haxe.lang.Runtime.concat("", (global::haxe.lang.Runtime.concat("", global::Std.@string(((long) (newAddress) ))))));
					floatingMask += ((long) (1) );
				}
				
				return writeAddresses;
			}
		}
		
		
		public static void decoderV1() {
			unchecked {
				string mask = "";
				{
					int _g = 0;
					global::Array<string> _g1 = global::solutions.Day14.arr;
					while (( _g < _g1.length )) {
						string line = _g1[_g];
						 ++ _g;
						global::Array<string> lineArr = global::haxe.lang.StringExt.split(line, "=");
						string instruct = lineArr[0].TrimEnd();
						if (( instruct == "mask" )) {
							mask = lineArr[1].TrimStart();
						}
						else if (( global::haxe.lang.StringExt.substr(instruct, 0, new global::haxe.lang.Null<int>(3, true)) == "mem" )) {
							string addr = global::haxe.lang.StringExt.split(instruct, "[")[1];
							{
								global::haxe.IMap<string, long> this1 = global::solutions.Day14.memory;
								string k = global::haxe.lang.StringExt.substr(addr, 0, new global::haxe.lang.Null<int>(( addr.Length - 1 ), true));
								long v = global::solutions.Day14.applyMaskToValue(mask, ((long) ((global::Std.parseInt(lineArr[1].TrimStart())).@value) ));
								((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (this1) ))) ).@set(k, v);
							}
							
						}
						
					}
					
				}
				
				long sum = ((long) (0) );
				{
					object key = ((object) (new global::haxe.ds._StringMap.StringMapKeyIterator<long>(((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (((global::haxe.IMap<string, long>) (global::solutions.Day14.memory) )) ))) ))) );
					while (global::haxe.lang.Runtime.toBool(global::haxe.lang.Runtime.callField(key, "hasNext", 407283053, null))) {
						string key1 = global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.callField(key, "next", 1224901875, null));
						sum = ( ((long) (sum) ) + (((global::haxe.ds.StringMap<long>) (global::haxe.ds.StringMap<object>.__hx_cast<long>(((global::haxe.ds.StringMap) (((global::haxe.IMap<string, long>) (global::solutions.Day14.memory) )) ))) ).@get(key1)).@value );
					}
					
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", (global::haxe.lang.Runtime.concat("", global::Std.@string(((long) (sum) )))))) ));
			}
		}
		
		
		public static long applyMaskToValue(string mask, long @value) {
			unchecked {
				long output = @value;
				int currBit = 0;
				long one = ((long) (1) );
				while (( currBit < mask.Length )) {
					switch (global::haxe.lang.StringExt.charAt(mask, ( ( mask.Length - 1 ) - currBit ))) {
						case "0":
						{
							output = ((long) (( ((long) (output) ) & ((long) ( ~ ((((long) (( ((long) (one) ) << currBit )) ))) ) ) )) );
							break;
						}
						
						
						case "1":
						{
							output = ((long) (( ((long) (output) ) | ((long) (( ((long) (one) ) << currBit )) ) )) );
							break;
						}
						
						
						case "X":
						{
							break;
						}
						
						
						default:
						{
							global::System.Console.WriteLine(((object) ("Unhandled bitmask character in applyMask()") ));
							break;
						}
						
					}
					
					 ++ currBit;
				}
				
				return output;
			}
		}
		
		
	}
}


