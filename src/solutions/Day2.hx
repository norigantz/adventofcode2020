package solutions;
using StringTools;

class Day2 {
    static var input:String = sys.io.File.getContent('inputs/Day2.txt');

    public static function solve() {
        Sys.println("Solving Day2");
        var arr:Array<String> = input.split('\r\n');
        var result = 0;
        for (line in arr) {
            var lineArr:Array<String> = line.split(':');
            var policy = lineArr[0];
            var password = lineArr[1].trim();
            Sys.println(policy + ', ' + password);

            //Policy processing
            var minMaxArr = policy.split('-');
            var min = Std.parseInt(minMaxArr[0]);
            var max = Std.parseInt(minMaxArr[1].split(' ')[0]);
            var char = minMaxArr[1].split(' ')[1];
            Sys.println('min: ' + min + ', max: ' + max + ', char: ' + char);

            //Password processing
            var count = password.split(char).length - 1;
            Sys.println('count: ' + count);
            if (count >= min && count <= max) result++;

            Sys.println('');
        }
        Sys.println(result);
    }
}