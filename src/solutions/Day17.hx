package solutions;

class Day17 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day17.txt');

    static var cubeGrid:Map<Int, Array<String>> = new Map<Int, Array<String>>();
    static var depth = 0;
    static var hyperDepth = 0;
    static var pretendWidth = 100;
    static var activeCubes = 0;

    public static function solve() {
        Sys.println("Solving Day17");
        var arr:Array<String> = input.split('\r\n');

        cubeGrid[0] = arr.copy();
        for (row in cubeGrid[0])
            for (char in row)
                if (""+char == '#') activeCubes++;
        // Sys.println(cubeGrid[0][1]);
        // Sys.println(getNeighbors(1, 0, 0, 1));
        // Sys.println(getNeighbors(1, 0, 0, 1));

        // drawFullGrid();
        // growGrid();
        // drawFullGrid();
        drawFullGrid();
        for (i in 0...6)
            iterateCubes(1);
        Sys.println('a: ' + activeCubes);
    }

    static function iterateCubes(distanceToNeighbors:Int):Int {
        growGrid();
        var newCubeGrid = copyGrid(cubeGrid);
        var cubesChanged = 0;
        var activeNeighbors:Int;
        for (z in -depth...depth+1) {
            for (row in 0...cubeGrid[z].length) {
                for (col in 0...cubeGrid[z][0].length) {
                    activeNeighbors = getNeighbors(row, col, z, distanceToNeighbors);
                    if (cubeGrid[z][row].charAt(col) == '.' && activeNeighbors == 3) {
                        newCubeGrid[z][row] = newCubeGrid[z][row].substr(0, col) + '#' + newCubeGrid[z][row].substr(col+1);
                        cubesChanged++;
                        activeCubes++;
                    }
                    else if (cubeGrid[z][row].charAt(col) == '#' && (activeNeighbors < 2 || activeNeighbors > 3)) {
                        newCubeGrid[z][row] = newCubeGrid[z][row].substr(0, col) + '.' + newCubeGrid[z][row].substr(col+1);
                        cubesChanged++;
                        activeCubes--;
                    }
                }
            }
        }
        cubeGrid = copyGrid(newCubeGrid);
        drawFullGrid();
        return cubesChanged;
    }

    static function growGrid() {
        var str:String = "";
        for (s in 0...cubeGrid[0][0].length+2)
            str += '.';
        for (z in -depth...depth+1) {
            for (i in 0...cubeGrid[z].length)
                cubeGrid[z][i] = '.' + cubeGrid[z][i] + '.';
            cubeGrid[z].unshift(str);
            cubeGrid[z].push(str);
        }
        depth++;
        cubeGrid[-depth] = new Array<String>();
        cubeGrid[depth] = new Array<String>();
        for (s in 0...cubeGrid[0].length) {
            cubeGrid[-depth].push(str);
            cubeGrid[depth].push(str);
        }
    }

    static function getNeighbors(row:Int, col:Int, z:Int, distance:Int):Int {
        var activeVisibleNeighbors:Int = 0;
        for (i in -1...2) {
            for (j in -1...2) {
                for (k in -1...2) {
                    if (!(i == 0 && j == 0 && k == 0) && castNeighbor(row, col, z, i, j, k, distance)) activeVisibleNeighbors++;
                }
            }
        }
        return activeVisibleNeighbors;
    }

    static function castNeighbor(row:Int, col:Int, z:Int, dRow:Int, dCol:Int, dZ:Int, distance:Int):Bool {
        var activeCubeNeighbor = false;
        var currRow = row+dRow;
        var currCol = col+dCol;
        var currZ = z+dZ;
        var currDist = 0;
        while (currRow > -1 && currRow < cubeGrid[z].length && currCol > -1 && currCol < cubeGrid[z][0].length && currZ >= -depth && currZ <= depth && currDist < distance) {
            if (cubeGrid[currZ][currRow].charAt(currCol) == '#') return true;
            else if (cubeGrid[currZ][currRow].charAt(currCol) == '.') return false;
            currRow += dRow;
            currCol += dCol;
            currZ += dZ;
            currDist++;
        }
        return activeCubeNeighbor;
    }

    static function copyGrid(grid:Map<Int, Array<String>>):Map<Int, Array<String>> {
        var newGrid = new Map<Int, Array<String>>();
        for (key in grid.keys())
            newGrid[key] = grid[key].copy();
        return newGrid;
    }

    static function drawFullGrid() {
        if (depth == 0) {
            drawGridSlice(0);
            return;
        }
        for (z in -depth...depth+1) {
            Sys.println('z='+z);
            for (row in cubeGrid[z]) {
                Sys.println(row);
            }
            Sys.println('');
        }
    }

    static function drawGridSlice(z:Int) {
        for (row in cubeGrid[z]) {
            Sys.println(row);
        }
        Sys.println("");
    }
}