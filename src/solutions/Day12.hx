package solutions;

class Day12 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day12.txt');

    static var facings:Array<String> = ['N', 'E', 'S', 'W'];
    static var currFacing:Int = 1;
    static var x:Int;
    static var y:Int;
    static var waypointX:Int = 10;
    static var waypointY:Int = 1;

    public static function solve() {
        Sys.println("Solving Day12");
        var arr:Array<String> = input.split('\r\n');

        for (instruction in arr) runInstruction(instruction);
        Sys.println('a: ' + (Math.abs(x) + Math.abs(y)));

        x = 0;
        y = 0;
        for (instruction in arr) runWaypointInstruction(instruction);
        Sys.println('b: ' + (Math.abs(x) + Math.abs(y)));
    }

    static function runWaypointInstruction(instruction:String) {
        var value = Std.parseInt(instruction.substr(1));
        switch(instruction.charAt(0)) {
            case 'N':
                moveWaypoint('N', value);
            case 'E':
                moveWaypoint('E', value);
            case 'S':
                moveWaypoint('S', value);
            case 'W':
                moveWaypoint('W', value);
            case 'L':
                for (i in 0...Std.int(value/90)) rotateWaypoint('L');
            case 'R':
                for (i in 0...Std.int(value/90)) rotateWaypoint('R');
            case 'F':
                for (i in 0...value) moveToWaypoint();
            default: Sys.println("Unhandled char found in instruction");
        }
    }

    static function moveWaypoint(direction:String, value:Int) {
        switch(direction) {
            case 'N':
                waypointY += value;
            case 'E':
                waypointX += value;
            case 'S':
                waypointY -= value;
            case 'W':
                waypointX -= value;
            default:
                Sys.println("Unhandled char found in move waypoint direction: " + direction);
        }
    }

    static function rotateWaypoint(direction:String) {
        if (direction == 'L') {
            var temp = waypointX;
            waypointX = -waypointY;
            waypointY = temp;
        }
        else if (direction == 'R') {
            var temp = waypointX;
            waypointX = waypointY;
            waypointY = -temp;
        }
    }

    static function moveToWaypoint() {
        x += waypointX;
        y += waypointY;
    }

    static function runInstruction(instruction:String) {
        var value = Std.parseInt(instruction.substr(1));
        switch(instruction.charAt(0)) {
            case 'N':
                move('N', value);
            case 'E':
                move('E', value);
            case 'S':
                move('S', value);
            case 'W':
                move('W', value);
            case 'L':
                currFacing = (currFacing+4 - Std.int(value/90)) % 4;
            case 'R':
                currFacing = (currFacing + Std.int(value/90)) % 4;
            case 'F':
                move(facings[currFacing], value);
            default: Sys.println("Unhandled char found in instruction");
        }
    }

    static function move(direction:String, value:Int) {
        switch(direction) {
            case 'N':
                y += value;
            case 'E':
                x += value;
            case 'S':
                y -= value;
            case 'W':
                x -= value;
            default:
                Sys.println("Unhandled char found in move direction: " + direction);
        }
    }
}