package solutions;

class Day11 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day11.txt');

    static var seatGrid:Array<String> = input.split('\r\n');
    static var occupiedSeats = 0;

    public static function solve() {
        Sys.println("Solving Day11");

        while (iterateSeating(1, 4) > 0) {}
        Sys.println('a: ' + occupiedSeats);

        seatGrid = input.split('\r\n');
        occupiedSeats = 0;

        while (iterateSeating(100, 5) > 0) {}
        Sys.println('b: ' + occupiedSeats);
    }

    static function iterateSeating(distanceToNeighbors:Int, occupancyTolerance:Int):Int {
        var newSeatGrid = seatGrid.copy();
        var seatsChanged = 0;
        var occupiedNeighbors:Int;
        for (row in 0...seatGrid.length) {
            for (col in 0...seatGrid[0].length) {
                occupiedNeighbors = getNeighbors(row, col, distanceToNeighbors);
                if (seatGrid[row].charAt(col) == 'L' && occupiedNeighbors == 0) {
                    newSeatGrid[row] = newSeatGrid[row].substr(0, col) + '#' + newSeatGrid[row].substr(col+1);
                    seatsChanged++;
                    occupiedSeats++;
                }
                else if (seatGrid[row].charAt(col) == '#' && occupiedNeighbors >= occupancyTolerance) {
                    newSeatGrid[row] = newSeatGrid[row].substr(0, col) + 'L' + newSeatGrid[row].substr(col+1);
                    seatsChanged++;
                    occupiedSeats--;
                }
            }
        }
        seatGrid = newSeatGrid.copy();
        return seatsChanged;
    }

    static function getNeighbors(row:Int, col:Int, distance:Int):Int {
        var occupiedVisibleNeighbors:Int = 0;
        for (i in -1...2) {
            for (j in -1...2) {
                if (!(i == 0 && j == 0) && castVision(row, col, i, j, distance)) occupiedVisibleNeighbors++;
            }
        }
        return occupiedVisibleNeighbors;
    }

    static function castVision(row:Int, col:Int, dRow:Int, dCol:Int, distance:Int):Bool {
        var occupiedSeatInView = false;
        var currRow = row+dRow;
        var currCol = col+dCol;
        var currDist = 0;
        while (currRow > -1 && currRow < seatGrid.length && currCol > -1 && currCol < seatGrid[0].length && currDist < distance) {
            if (seatGrid[currRow].charAt(currCol) == '#') return true;
            else if (seatGrid[currRow].charAt(currCol) == 'L') return false;
            currRow += dRow;
            currCol += dCol;
            currDist++;
        }
        return occupiedSeatInView;
    }

    static function drawGrid() {
        for (row in seatGrid) {
            Sys.println(row);
        }
        Sys.println("");
    }
}