package solutions;
import haxe.Int64;

class Day3 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day3.txt');

    public static function solve() {
        Sys.println("Solving Day3");
        var arr:Array<String> = input.split('\r\n');
        
        Sys.println("a: " + calcSlope(arr, 3, 1));
        var resultB:Int64 = calcSlope(arr, 1, 1) * calcSlope(arr, 3, 1) * calcSlope(arr, 5, 1) * calcSlope(arr, 7, 1) * calcSlope(arr, 1, 2);
        Sys.println("b: " + resultB);
    }

    static function calcSlope(arr:Array<String>, dx:Int, dy:Int):Int64 {
        var result:Int64 = 0;
        var x = dx;
        var y = dy;
        while (y < arr.length) {
            if (arr[y].charAt(x) == '#') result++;
            x = (x + dx) % arr[0].length;
            y += dy;
        }
        return result;
    }
}