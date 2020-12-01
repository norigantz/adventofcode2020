package solutions;

class Day1 {
    static var input:String = sys.io.File.getContent('inputs/Day1.txt');

    public static function solve() {
        Sys.println("Solving day 1");
        var arr:Array<Int> = input.split('\r\n').map(Std.parseInt);
        solve_a(arr);
        solve_b(arr);
    }

    static function solve_a(arr:Array<Int>) {
        var result:Array<Int> = sum_exists(arr, 2020);
        Sys.println("a: " + result[0] * result[1]);
    }

    static function solve_b(arr:Array<Int>) {
        var curr:Int = 0;
        var result:Array<Int> = null;
        for (a in arr) {
            curr = a;
            result = sum_exists(arr, 2020-curr);
            if (result != null) break;
        }
        Sys.println("b: " + curr * result[0] * result[1]);
    }

    //Returns two ints, both from Array<Int> arr, that sum to Int sumTarget
    static function sum_exists(arr:Array<Int>, sumTarget:Int):Array<Int> {
        var arrCopy = arr.copy();
        var curr:Null<Int> = 0;
        var diff:Int;
        var str:String;
        while(curr != null) {
            curr = arrCopy.shift();
            diff = sumTarget - curr;
            if(arrCopy.contains(diff)) return [curr, diff];
        }
        return null;
    }
}