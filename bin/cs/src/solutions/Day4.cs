// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day4 : global::haxe.lang.HxObject {
		
		static Day4() {
			global::solutions.Day4.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day4.txt");
			global::solutions.Day4.required = new global::Array<string>(new string[]{"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"});
		}
		
		
		public Day4(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day4() {
			global::solutions.Day4.__hx_ctor_solutions_Day4(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day4(global::solutions.Day4 __hx_this) {
		}
		
		
		public static string input;
		
		public static global::Array<string> required;
		
		public static void solve() {
			global::System.Console.WriteLine(((object) ("Solving Day4") ));
			global::Array<string> arr = global::haxe.lang.StringExt.split(global::solutions.Day4.input, "\r\n\r\n");
			int resultA = 0;
			int resultB = 0;
			{
				int _g = 0;
				while (( _g < arr.length )) {
					string passport = arr[_g];
					 ++ _g;
					global::haxe.ds.StringMap<string> keyValues = global::solutions.Day4.processPassport(passport);
					if (global::solutions.Day4.hasRequiredFields(keyValues)) {
						 ++ resultA;
						if (global::solutions.Day4.hasValidValues(keyValues)) {
							 ++ resultB;
						}
						
					}
					
				}
				
			}
			
			global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(resultA))) ));
			global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", global::haxe.lang.Runtime.toString(resultB))) ));
		}
		
		
		public static global::haxe.ds.StringMap<string> processPassport(string passport) {
			unchecked {
				global::Array<string> fields = new global::EReg("[ ]|\r\n", "g").split(passport);
				global::haxe.ds.StringMap<string> keyValues = new global::haxe.ds.StringMap<string>();
				{
					int _g = 0;
					while (( _g < fields.length )) {
						string field = fields[_g];
						 ++ _g;
						{
							string k = global::haxe.lang.StringExt.substr(field, 0, new global::haxe.lang.Null<int>(3, true));
							string v = global::haxe.lang.StringExt.substr(field, 4, new global::haxe.lang.Null<int>(( field.Length - 4 ), true));
							keyValues.@set(k, v);
						}
						
					}
					
				}
				
				return keyValues;
			}
		}
		
		
		public static bool hasRequiredFields(global::haxe.ds.StringMap<string> keyValues) {
			{
				int _g = 0;
				global::Array<string> _g1 = global::solutions.Day4.required;
				while (( _g < _g1.length )) {
					string requirement = _g1[_g];
					 ++ _g;
					if ( ! (keyValues.exists(requirement)) ) {
						return false;
					}
					
				}
				
			}
			
			return true;
		}
		
		
		public static bool hasValidValues(global::haxe.ds.StringMap<string> keyValues) {
			{
				object key = ((object) (new global::haxe.ds._StringMap.StringMapKeyIterator<string>(((global::haxe.ds.StringMap<string>) (keyValues) ))) );
				while (global::haxe.lang.Runtime.toBool(global::haxe.lang.Runtime.callField(key, "hasNext", 407283053, null))) {
					string key1 = global::haxe.lang.Runtime.toString(global::haxe.lang.Runtime.callField(key, "next", 1224901875, null));
					if ( ! (global::solutions.Day4.isFieldValid(key1, global::haxe.lang.Runtime.toString((keyValues.@get(key1)).toDynamic()))) ) {
						return false;
					}
					
				}
				
			}
			
			return true;
		}
		
		
		public static bool isFieldValid(string key, string @value) {
			unchecked {
				switch (key) {
					case "byr":
					{
						global::haxe.lang.Null<int> numVal = global::Std.parseInt(@value);
						if (( ( @value.Length == 4 ) && ( (numVal).@value >= 1920 ) )) {
							return ( (numVal).@value <= 2002 );
						}
						else {
							return false;
						}
						
					}
					
					
					case "cid":
					{
						return true;
					}
					
					
					case "ecl":
					{
						return new global::EReg("(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)", "").match(@value);
					}
					
					
					case "eyr":
					{
						global::haxe.lang.Null<int> numVal1 = global::Std.parseInt(@value);
						if (( ( @value.Length == 4 ) && ( (numVal1).@value >= 2020 ) )) {
							return ( (numVal1).@value <= 2030 );
						}
						else {
							return false;
						}
						
					}
					
					
					case "hcl":
					{
						if (( ( global::haxe.lang.StringExt.charAt(@value, 0) == "#" ) && ( @value.Length == 7 ) )) {
							return new global::EReg("[0-9]|[a-f]", "").match(@value);
						}
						
						break;
					}
					
					
					case "hgt":
					{
						global::haxe.lang.Null<int> numVal2 = global::Std.parseInt(@value);
						if (new global::EReg("(cm)", "").match(@value)) {
							if (( (numVal2).@value >= 150 )) {
								return ( (numVal2).@value <= 193 );
							}
							else {
								return false;
							}
							
						}
						else if (new global::EReg("(in)", "").match(@value)) {
							if (( (numVal2).@value >= 59 )) {
								return ( (numVal2).@value <= 76 );
							}
							else {
								return false;
							}
							
						}
						
						break;
					}
					
					
					case "iyr":
					{
						global::haxe.lang.Null<int> numVal3 = global::Std.parseInt(@value);
						if (( ( @value.Length == 4 ) && ( (numVal3).@value >= 2010 ) )) {
							return ( (numVal3).@value <= 2020 );
						}
						else {
							return false;
						}
						
					}
					
					
					case "pid":
					{
						if (( @value.Length == 9 )) {
							return new global::EReg("[0-9]", "").match(@value);
						}
						
						break;
					}
					
					
					default:
					{
						global::System.Console.WriteLine(((object) ("Bad key provided to validator") ));
						break;
					}
					
				}
				
				return false;
			}
		}
		
		
	}
}


