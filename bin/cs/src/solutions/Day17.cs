// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day17 : global::haxe.lang.HxObject {
		
		static Day17() {
			global::solutions.Day17.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day17.txt");
			global::solutions.Day17.activeCubes = 0;
			global::solutions.Day17.grid = new global::Array<string>();
		}
		
		
		public Day17(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day17() {
			global::solutions.Day17.__hx_ctor_solutions_Day17(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day17(global::solutions.Day17 __hx_this) {
		}
		
		
		public static string input;
		
		public static int activeCubes;
		
		public static global::Array<string> grid;
		
		public static int width;
		
		public static int height;
		
		public static int length;
		
		public static int trength;
		
		public static void solve() {
			unchecked {
				global::System.Console.WriteLine(((object) ("Solving Day17") ));
				global::Array<string> arr = global::haxe.lang.StringExt.split(global::solutions.Day17.input, "\r\n");
				global::solutions.Day17.width = arr[0].Length;
				global::solutions.Day17.height = arr.length;
				global::solutions.Day17.length = 1;
				global::solutions.Day17.trength = 1;
				global::solutions.Day17.grid.resize(( global::solutions.Day17.width * global::solutions.Day17.height ));
				{
					int _g = 0;
					int _g1 = arr.length;
					while (( _g < _g1 )) {
						int y = _g++;
						{
							int _g2 = 0;
							int _g3 = arr[0].Length;
							while (( _g2 < _g3 )) {
								int x = _g2++;
								string @char = global::haxe.lang.StringExt.charAt(arr[y], x);
								global::solutions.Day17.grid[global::solutions.Day17.index(x, y, 0, 0)] = @char;
								if (( @char == "#" )) {
									global::solutions.Day17.activeCubes++;
								}
								
							}
							
						}
						
					}
					
				}
				
				{
					global::solutions.Day17.iterateCubes(1);
					global::solutions.Day17.iterateCubes(1);
					global::solutions.Day17.iterateCubes(1);
					global::solutions.Day17.iterateCubes(1);
					global::solutions.Day17.iterateCubes(1);
					global::solutions.Day17.iterateCubes(1);
				}
				
				global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("a: ", global::haxe.lang.Runtime.toString(global::solutions.Day17.activeCubes))) ));
			}
		}
		
		
		public static void iterateCubes(int distanceToNeighbors) {
			unchecked {
				global::solutions.Day17.growGrid();
				global::Array<string> newGrid = global::solutions.Day17.grid.copy();
				int activeNeighbors = default(int);
				{
					int _g = 0;
					int _g1 = global::solutions.Day17.trength;
					while (( _g < _g1 )) {
						int w = _g++;
						{
							int _g2 = 0;
							int _g3 = global::solutions.Day17.length;
							while (( _g2 < _g3 )) {
								int z = _g2++;
								{
									int _g4 = 0;
									int _g5 = global::solutions.Day17.height;
									while (( _g4 < _g5 )) {
										int y = _g4++;
										{
											int _g6 = 0;
											int _g7 = global::solutions.Day17.width;
											while (( _g6 < _g7 )) {
												int x = _g6++;
												activeNeighbors = global::solutions.Day17.getNeighbors(x, y, z, w);
												if (( (( ( global::solutions.Day17.grid[global::solutions.Day17.index(x, y, z, w)] == "." ) || ( global::solutions.Day17.grid[global::solutions.Day17.index(x, y, z, w)] == null ) )) && ( activeNeighbors == 3 ) )) {
													newGrid[global::solutions.Day17.index(x, y, z, w)] = "#";
													global::solutions.Day17.activeCubes++;
												}
												else if (( ( global::solutions.Day17.grid[global::solutions.Day17.index(x, y, z, w)] == "#" ) && (( ( activeNeighbors < 2 ) || ( activeNeighbors > 3 ) )) )) {
													newGrid[global::solutions.Day17.index(x, y, z, w)] = ".";
													global::solutions.Day17.activeCubes--;
												}
												
											}
											
										}
										
									}
									
								}
								
							}
							
						}
						
					}
					
				}
				
				global::solutions.Day17.grid = newGrid.copy();
			}
		}
		
		
		public static void growGrid() {
			unchecked {
				int newWidth = ( global::solutions.Day17.width + 2 );
				int newHeight = ( global::solutions.Day17.height + 2 );
				int newLength = ( global::solutions.Day17.length + 2 );
				int newTrength = ( global::solutions.Day17.trength + 2 );
				global::Array<string> newGrid = new global::Array<string>();
				newGrid.resize(( ( ( newWidth * newHeight ) * newLength ) * newTrength ));
				{
					int _g = 0;
					int _g1 = global::solutions.Day17.trength;
					while (( _g < _g1 )) {
						int w = _g++;
						{
							int _g2 = 0;
							int _g3 = global::solutions.Day17.length;
							while (( _g2 < _g3 )) {
								int z = _g2++;
								{
									int _g4 = 0;
									int _g5 = global::solutions.Day17.height;
									while (( _g4 < _g5 )) {
										int y = _g4++;
										{
											int _g6 = 0;
											int _g7 = global::solutions.Day17.width;
											while (( _g6 < _g7 )) {
												int x = _g6++;
												newGrid[global::solutions.Day17.growIndex(( x + 1 ), ( y + 1 ), ( z + 1 ), ( w + 1 ))] = global::solutions.Day17.grid[global::solutions.Day17.index(x, y, z, w)];
											}
											
										}
										
									}
									
								}
								
							}
							
						}
						
					}
					
				}
				
				global::solutions.Day17.width = newWidth;
				global::solutions.Day17.height = newHeight;
				global::solutions.Day17.length = newLength;
				global::solutions.Day17.trength = newTrength;
				global::solutions.Day17.grid = newGrid.copy();
			}
		}
		
		
		public static int getNeighbors(int x, int y, int z, int w) {
			unchecked {
				int activeVisibleNeighbors = 0;
				{
					{
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, -1, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 0, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, -1, 1, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
					}
					
					{
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, -1, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 0, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 0, 1, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
					}
					
					{
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, -1, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 0, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
						{
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, -1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, -1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, -1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, 0, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, 0, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, 0, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
							{
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, 1, -1)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, 1, 0)) {
									 ++ activeVisibleNeighbors;
								}
								
								if (global::solutions.Day17.checkNeighbor(x, y, z, w, 1, 1, 1, 1)) {
									 ++ activeVisibleNeighbors;
								}
								
							}
							
						}
						
					}
					
				}
				
				return activeVisibleNeighbors;
			}
		}
		
		
		public static bool checkNeighbor(int x, int y, int z, int w, int dX, int dY, int dZ, int dW) {
			unchecked {
				bool activeCubeNeighbor = false;
				int currX = ( x + dX );
				int currY = ( y + dY );
				int currZ = ( z + dZ );
				int currW = ( w + dW );
				if (( ( ( ( ( ( ( ( currX > -1 ) && ( currX < global::solutions.Day17.width ) ) && ( currY > -1 ) ) && ( currY < global::solutions.Day17.height ) ) && ( currZ > -1 ) ) && ( currZ < global::solutions.Day17.length ) ) && ( currW > -1 ) ) && ( currW < global::solutions.Day17.trength ) )) {
					if (( global::solutions.Day17.grid[global::solutions.Day17.index(currX, currY, currZ, currW)] == "#" )) {
						return true;
					}
					else if (( ( global::solutions.Day17.grid[global::solutions.Day17.index(currX, currY, currZ, currW)] == "." ) || ( global::solutions.Day17.grid[global::solutions.Day17.index(currX, currY, currZ, currW)] == null ) )) {
						return false;
					}
					
				}
				
				return activeCubeNeighbor;
			}
		}
		
		
		public static int growIndex(int x, int y, int z, int w) {
			unchecked {
				return ( ( ( ( ( ( (( global::solutions.Day17.width + 2 )) * (( global::solutions.Day17.height + 2 )) ) * (( global::solutions.Day17.length + 2 )) ) * w ) + ( ( (( global::solutions.Day17.width + 2 )) * (( global::solutions.Day17.height + 2 )) ) * z ) ) + ( (( global::solutions.Day17.width + 2 )) * y ) ) + x );
			}
		}
		
		
		public static int index(int x, int y, int z, int w) {
			return ( ( ( ( ( ( global::solutions.Day17.width * global::solutions.Day17.height ) * global::solutions.Day17.length ) * w ) + ( ( global::solutions.Day17.width * global::solutions.Day17.height ) * z ) ) + ( global::solutions.Day17.width * y ) ) + x );
		}
		
		
		public static void drawFullGrid() {
			int _g = 0;
			int _g1 = global::solutions.Day17.length;
			while (( _g < _g1 )) {
				int z = _g++;
				global::solutions.Day17.drawGridSlice(z);
			}
			
		}
		
		
		public static void drawGridSlice(int z) {
			global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("z=", global::haxe.lang.Runtime.toString(z))) ));
			{
				int _g = 0;
				int _g1 = global::solutions.Day17.height;
				while (( _g < _g1 )) {
					int y = _g++;
					string str = "";
					{
						int _g2 = 0;
						int _g3 = global::solutions.Day17.width;
						while (( _g2 < _g3 )) {
							int x = _g2++;
							str = global::haxe.lang.Runtime.concat(str, global::solutions.Day17.grid[global::solutions.Day17.index(x, y, z, 0)]);
						}
						
					}
					
					global::System.Console.WriteLine(((object) (str) ));
				}
				
			}
			
			global::System.Console.WriteLine(((object) ("") ));
		}
		
		
	}
}

