// Generated by Haxe 4.1.2

#pragma warning disable 109, 114, 219, 429, 168, 162
namespace solutions {
	public class Day17 : global::haxe.lang.HxObject {
		
		static Day17() {
			unchecked{
				global::solutions.Day17.input = global::sys.io.File.getContent("E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day17.txt");
				global::solutions.Day17.cubeGrid = new global::haxe.ds.IntMap<object>();
				global::solutions.Day17.depth = 0;
				global::solutions.Day17.hyperDepth = 0;
				global::solutions.Day17.pretendWidth = 100;
				global::solutions.Day17.activeCubes = 0;
			}
		}
		
		
		public Day17(global::haxe.lang.EmptyObject empty) {
		}
		
		
		public Day17() {
			global::solutions.Day17.__hx_ctor_solutions_Day17(this);
		}
		
		
		protected static void __hx_ctor_solutions_Day17(global::solutions.Day17 __hx_this) {
		}
		
		
		public static string input;
		
		public static global::haxe.ds.IntMap<object> cubeGrid;
		
		public static int depth;
		
		public static int hyperDepth;
		
		public static int pretendWidth;
		
		public static int activeCubes;
		
		public static void solve() {
			unchecked {
				global::System.Console.WriteLine(((object) ("Solving Day17") ));
				global::Array<string> arr = global::haxe.lang.StringExt.split(global::solutions.Day17.input, "\r\n");
				{
					global::haxe.IMap<int, object> this1 = global::solutions.Day17.cubeGrid;
					global::Array<string> v = arr.copy();
					((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (this1) ))) ).@set(0, v);
				}
				
				{
					int _g = 0;
					global::Array<string> _g1 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(0)).@value) ))) );
					while (( _g < _g1.length )) {
						string row = _g1[_g];
						 ++ _g;
						{
							int _g2 = 0;
							while (( _g2 < row.Length )) {
								char @char = row[_g2];
								 ++ _g2;
								if (( global::haxe.lang.Runtime.concat("", global::Std.@string(@char)) == "#" )) {
									global::solutions.Day17.activeCubes++;
								}
								
							}
							
						}
						
					}
					
				}
				
				global::solutions.Day17.drawFullGrid();
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
		
		
		public static int iterateCubes(int distanceToNeighbors) {
			unchecked {
				global::solutions.Day17.growGrid();
				global::haxe.ds.IntMap<object> newCubeGrid = global::solutions.Day17.copyGrid(global::solutions.Day17.cubeGrid);
				int cubesChanged = 0;
				int activeNeighbors = default(int);
				{
					int _g =  - (global::solutions.Day17.depth) ;
					int _g1 = ( global::solutions.Day17.depth + 1 );
					while (( _g < _g1 )) {
						int z = _g++;
						{
							int _g2 = 0;
							int _g3 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) ).length;
							while (( _g2 < _g3 )) {
								int row = _g2++;
								{
									int _g4 = 0;
									int _g5 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) )[0].Length;
									while (( _g4 < _g5 )) {
										int col = _g4++;
										activeNeighbors = global::solutions.Day17.getNeighbors(row, col, z, distanceToNeighbors);
										if (( ( global::haxe.lang.StringExt.charAt(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) )[row], col) == "." ) && ( activeNeighbors == 3 ) )) {
											((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((newCubeGrid.@get(z)).@value) ))) )[row] = global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.StringExt.substr(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((newCubeGrid.@get(z)).@value) ))) )[row], 0, new global::haxe.lang.Null<int>(col, true)), "#"), global::haxe.lang.StringExt.substr(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((newCubeGrid.@get(z)).@value) ))) )[row], ( col + 1 ), default(global::haxe.lang.Null<int>)));
											 ++ cubesChanged;
											global::solutions.Day17.activeCubes++;
										}
										else if (( ( global::haxe.lang.StringExt.charAt(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) )[row], col) == "#" ) && (( ( activeNeighbors < 2 ) || ( activeNeighbors > 3 ) )) )) {
											((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((newCubeGrid.@get(z)).@value) ))) )[row] = global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(global::haxe.lang.StringExt.substr(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((newCubeGrid.@get(z)).@value) ))) )[row], 0, new global::haxe.lang.Null<int>(col, true)), "."), global::haxe.lang.StringExt.substr(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((newCubeGrid.@get(z)).@value) ))) )[row], ( col + 1 ), default(global::haxe.lang.Null<int>)));
											 ++ cubesChanged;
											global::solutions.Day17.activeCubes--;
										}
										
									}
									
								}
								
							}
							
						}
						
					}
					
				}
				
				global::solutions.Day17.cubeGrid = global::solutions.Day17.copyGrid(newCubeGrid);
				global::solutions.Day17.drawFullGrid();
				return cubesChanged;
			}
		}
		
		
		public static void growGrid() {
			unchecked {
				string str = "";
				{
					int _g = 0;
					int _g1 = ( ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(0)).@value) ))) )[0].Length + 2 );
					while (( _g < _g1 )) {
						int s = _g++;
						str = global::haxe.lang.Runtime.concat(str, ".");
					}
					
				}
				
				{
					int _g2 =  - (global::solutions.Day17.depth) ;
					int _g3 = ( global::solutions.Day17.depth + 1 );
					while (( _g2 < _g3 )) {
						int z = _g2++;
						{
							int _g4 = 0;
							int _g5 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) ).length;
							while (( _g4 < _g5 )) {
								int i = _g4++;
								((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) )[i] = global::haxe.lang.Runtime.concat(global::haxe.lang.Runtime.concat(".", ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) )[i]), ".");
							}
							
						}
						
						((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) ).unshift(str);
						((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) ).push(str);
					}
					
				}
				
				global::solutions.Day17.depth++;
				{
					global::haxe.IMap<int, object> this1 = global::solutions.Day17.cubeGrid;
					int k =  - (global::solutions.Day17.depth) ;
					global::Array<string> v = new global::Array<string>();
					((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (this1) ))) ).@set(k, v);
				}
				
				{
					global::haxe.IMap<int, object> this11 = global::solutions.Day17.cubeGrid;
					int k1 = global::solutions.Day17.depth;
					global::Array<string> v1 = new global::Array<string>();
					((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (this11) ))) ).@set(k1, v1);
				}
				
				{
					int _g6 = 0;
					int _g7 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(0)).@value) ))) ).length;
					while (( _g6 < _g7 )) {
						int s1 = _g6++;
						((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get( - (global::solutions.Day17.depth) )).@value) ))) ).push(str);
						((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(global::solutions.Day17.depth)).@value) ))) ).push(str);
					}
					
				}
				
			}
		}
		
		
		public static int getNeighbors(int row, int col, int z, int distance) {
			unchecked {
				int activeVisibleNeighbors = 0;
				{
					{
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, -1, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, -1, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, -1, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, 0, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, 0, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, 0, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, 1, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, 1, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, -1, 1, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
					}
					
					{
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, -1, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, -1, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, -1, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, 0, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, 0, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, 1, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, 1, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 0, 1, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
					}
					
					{
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, -1, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, -1, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, -1, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, 0, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, 0, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, 0, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
						{
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, 1, -1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, 1, 0, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
							if (global::solutions.Day17.castNeighbor(row, col, z, 1, 1, 1, distance)) {
								 ++ activeVisibleNeighbors;
							}
							
						}
						
					}
					
				}
				
				return activeVisibleNeighbors;
			}
		}
		
		
		public static bool castNeighbor(int row, int col, int z, int dRow, int dCol, int dZ, int distance) {
			unchecked {
				bool activeCubeNeighbor = false;
				int currRow = ( row + dRow );
				int currCol = ( col + dCol );
				int currZ = ( z + dZ );
				int currDist = 0;
				while (( ( ( ( ( ( ( currRow > -1 ) && ( currRow < ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) ).length ) ) && ( currCol > -1 ) ) && ( currCol < ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) )[0].Length ) ) && ( currZ >=  - (global::solutions.Day17.depth)  ) ) && ( currZ <= global::solutions.Day17.depth ) ) && ( currDist < distance ) )) {
					if (( global::haxe.lang.StringExt.charAt(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(currZ)).@value) ))) )[currRow], currCol) == "#" )) {
						return true;
					}
					else if (( global::haxe.lang.StringExt.charAt(((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(currZ)).@value) ))) )[currRow], currCol) == "." )) {
						return false;
					}
					
					currRow += dRow;
					currCol += dCol;
					currZ += dZ;
					 ++ currDist;
				}
				
				return activeCubeNeighbor;
			}
		}
		
		
		public static global::haxe.ds.IntMap<object> copyGrid(global::haxe.ds.IntMap<object> grid) {
			global::haxe.ds.IntMap<object> newGrid = new global::haxe.ds.IntMap<object>();
			{
				object key = ((object) (new global::haxe.ds._IntMap.IntMapKeyIterator<object>(((global::haxe.ds.IntMap<object>) (grid) ))) );
				while (global::haxe.lang.Runtime.toBool(global::haxe.lang.Runtime.callField(key, "hasNext", 407283053, null))) {
					int key1 = ((int) (global::haxe.lang.Runtime.toInt(global::haxe.lang.Runtime.callField(key, "next", 1224901875, null))) );
					global::Array<string> v = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((grid.@get(key1)).@value) ))) ).copy();
					newGrid.@set(key1, v);
				}
				
			}
			
			return newGrid;
		}
		
		
		public static void drawFullGrid() {
			unchecked {
				if (( global::solutions.Day17.depth == 0 )) {
					global::solutions.Day17.drawGridSlice(0);
					return;
				}
				
				{
					int _g =  - (global::solutions.Day17.depth) ;
					int _g1 = ( global::solutions.Day17.depth + 1 );
					while (( _g < _g1 )) {
						int z = _g++;
						global::System.Console.WriteLine(((object) (global::haxe.lang.Runtime.concat("z=", global::haxe.lang.Runtime.toString(z))) ));
						{
							int _g2 = 0;
							global::Array<string> _g3 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) );
							while (( _g2 < _g3.length )) {
								string row = _g3[_g2];
								 ++ _g2;
								global::System.Console.WriteLine(((object) (row) ));
							}
							
						}
						
						global::System.Console.WriteLine(((object) ("") ));
					}
					
				}
				
			}
		}
		
		
		public static void drawGridSlice(int z) {
			{
				int _g = 0;
				global::Array<string> _g1 = ((global::Array<string>) (global::Array<object>.__hx_cast<string>(((global::Array) ((((global::haxe.ds.IntMap<object>) (global::haxe.ds.IntMap<object>.__hx_cast<object>(((global::haxe.ds.IntMap) (((global::haxe.IMap<int, object>) (global::solutions.Day17.cubeGrid) )) ))) ).@get(z)).@value) ))) );
				while (( _g < _g1.length )) {
					string row = _g1[_g];
					 ++ _g;
					global::System.Console.WriteLine(((object) (row) ));
				}
				
			}
			
			global::System.Console.WriteLine(((object) ("") ));
		}
		
		
	}
}


