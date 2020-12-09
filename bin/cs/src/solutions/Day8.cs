// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day8 : global::haxe.lang.HxObject {
		
		static Day8() {
			global::solutions.Day8.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day8.txt");
		}
		
		
		public Day8(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day8() {
			global::solutions.Day8.__hx_ctor_solutions_Day8(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day8(global::solutions.Day8 __hx_this) {
		}
		
		
		public static string input;
		
		public static void solve() {
			unchecked {
				global::System.Console.WriteLine(((object) ("Solving Day8") ));
				global::Array<string> arr = global::haxe.lang.StringExt.split(global::solutions.Day8.input, "\r\n");
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(global::solutions.Day8.runInstructions(arr, -1)[0]))) ));
				{
					int _g = 0;
					int _g1 = arr.length;
					while (( _g < _g1 )) {
						int i = _g++;
						global::Array<int> resultArr = global::solutions.Day8.runInstructions(arr, i);
						if (( resultArr[1] > -1 )) {
							global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("b: ", global::haxe.lang.Runtime.toString(resultArr[0]))) ));
							break;
						}
						
					}
					
				}
				
			}
		}
		
		
		public static global::Array<int> runInstructions(global::Array<string> instructions, int flipPointer) {
			unchecked {
				int opPointer = 0;
				global::Array<int> opHistory = new global::Array<int>();
				int accumulator = 0;
				int programTerminated = -1;
				while ( ! (opHistory.contains(opPointer)) ) {
					if (( opPointer == instructions.length )) {
						programTerminated = 1;
						break;
					}
					
					global::Array<string> instructionArr = global::haxe.lang.StringExt.split(instructions[opPointer], " ");
					if (( opPointer == flipPointer )) {
						if (( global::haxe.lang.StringExt.indexOf(instructionArr[0], "jmp", default(global::haxe.lang.Null<int>)) > -1 )) {
							instructionArr[0] = "nop";
						}
						else if (( global::haxe.lang.StringExt.indexOf(instructionArr[0], "nop", default(global::haxe.lang.Null<int>)) > -1 )) {
							instructionArr[0] = "jmp";
						}
						
					}
					
					opHistory.push(opPointer);
					switch (instructionArr[0]) {
						case "acc":
						{
							accumulator += (global::Std.parseInt(instructionArr[1])).@value;
							 ++ opPointer;
							break;
						}
						
						
						case "jmp":
						{
							opPointer += (global::Std.parseInt(instructionArr[1])).@value;
							break;
						}
						
						
						case "nop":
						{
							 ++ opPointer;
							break;
						}
						
						
						default:
						{
							global::System.Console.WriteLine(((object) ("Bad instruction") ));
							break;
						}
						
					}
					
				}
				
				return new global::Array<int>(new int[]{accumulator, programTerminated});
			}
		}
		
		
	}
}

