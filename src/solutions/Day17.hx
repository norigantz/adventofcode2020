package solutions;

class Day17 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day17.txt');

    static var activeCubes = 0;

    static var grid:Array<String> = new Array<String>();
    static var width:Int;
    static var height:Int;
    static var length:Int;
    static var trength:Int;

    public static function solve() {
        Sys.println("Solving Day17");
        var arr:Array<String> = input.split('\r\n');

        width = arr[0].length;
        height = arr.length;
        length = 1;
        trength = 1;
        grid.resize(width*height);

        for (y in 0...arr.length) {
            for (x in 0...arr[0].length) {
                var char = arr[y].charAt(x);
                grid[index(x, y, 0, 0)] = char;
                if (char == '#') activeCubes++;
            }
        }

        for (i in 0...6)
            iterateCubes();
        Sys.println('a: ' + activeCubes);
    }

    static function iterateCubes() {
        growGrid();
        var newGrid = grid.copy();
        var activeNeighbors:Int;
        for (w in 0...trength) {
            for (z in 0...length) {
                for (y in 0...height) {
                    for (x in 0...width) {
                        activeNeighbors = getNeighbors(x, y, z, w);
                        if ((grid[index(x, y, z, w)] == '.' || grid[index(x, y, z, w)] == null) && activeNeighbors == 3) {
                            newGrid[index(x, y, z, w)] = '#';
                            activeCubes++;
                        }
                        else if (grid[index(x, y, z, w)] == '#' && (activeNeighbors < 2 || activeNeighbors > 3)) {
                            newGrid[index(x, y, z, w)] = '.';
                            activeCubes--;
                        }
                    }
                }
            }
        }
        grid = newGrid.copy();
    }

    static function growGrid() {
        var newWidth = width + 2;
        var newHeight = height + 2;
        var newLength = length + 2;
        var newTrength = trength + 2;
        var newGrid = new Array<String>();
        newGrid.resize(newWidth*newHeight*newLength*newTrength);
        for (w in 0...trength)
            for (z in 0...length)
                for (y in 0...height)
                    for (x in 0...width)
                        newGrid[growIndex(x+1, y+1, z+1, w+1)] = grid[index(x, y, z, w)];
        width = newWidth;
        height = newHeight;
        length = newLength;
        trength = newTrength;
        grid = newGrid.copy();
    }

    static function getNeighbors(x:Int, y:Int, z:Int, w:Int):Int {
        var activeVisibleNeighbors:Int = 0;
        for (i in -1...2)
            for (j in -1...2)
                for (k in -1...2)
                    for (l in -1...2)
                        if (!(i == 0 && j == 0 && k == 0 && l == 0) && checkNeighbor(x, y, z, w, i, j, k, l)) activeVisibleNeighbors++;
        return activeVisibleNeighbors;
    }

    static function checkNeighbor(x:Int, y:Int, z:Int, w:Int, dX:Int, dY:Int, dZ:Int, dW:Int):Bool {
        var currX = x+dX;
        var currY = y+dY;
        var currZ = z+dZ;
        var currW = w+dW;
        if (currX > -1 && currX < width && currY > -1 && currY < height && currZ > -1 && currZ < length && currW > -1 && currW < trength && grid[index(currX, currY, currZ, currW)] == '#') return true;
        else return false;
    }

    static function growIndex(x:Int, y:Int, z:Int, w:Int):Int {
        return ((width+2)*(height+2)*(length+2)*w + (width+2)*(height+2)*z + (width+2)*y + x);
    }

    static function index(x:Int, y:Int, z:Int, w:Int):Int {
        return (width*height*length*w + width*height*z + width*y + x);
    }

    static function drawFullGrid() {
        for (z in 0...length)
            drawGridSlice(z);
    }

    static function drawGridSlice(z:Int) {
        Sys.println('z=' + z);
        for (y in 0...height) {
            var str = '';
            for (x in 0...width) {
                str += grid[index(x, y, z, 0)];
            }
            Sys.println(str);
        }
        Sys.println("");
    }
}