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
        Sys.println("a: " + multSum(arr, 2020));
    }

    static function solve_b(arr:Array<Int>) {
        var curr:Int = 0;
        var res:Int = -1;

        for (a in arr) {
            curr = a;
            res = multSum(arr, 2020-curr);
            if(res > -1) break;
        }
        Sys.println("b: " + curr * res);
    }

    static function multSum(arr:Array<Int>, sumTarget:Int):Int {
        for (i in 0...arr.length) {
            for (j in i...arr.length) {
                if (arr[j] == sumTarget - arr[i]) return arr[i] * arr[j];
            }
        }
        return -1;
    }
}