package solutions;
using StringTools;

class Day2 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day2.txt');

    public static function solve() {
        Sys.println("Solving Day2");
        var arr:Array<String> = input.split('\r\n');
        var resultA = 0;
        var resultB = 0;

        for (line in arr) {
            var lineArr:Array<String> = line.split(':');
            var policy = lineArr[0];
            var password = lineArr[1].trim();
            // Sys.println(policy + ', ' + password);

            //Policy processing
            var minMaxArr = policy.split('-');
            var min = Std.parseInt(minMaxArr[0]);
            var max = Std.parseInt(minMaxArr[1].split(' ')[0]);
            var char = minMaxArr[1].split(' ')[1];
            // Sys.println('min: ' + min + ', max: ' + max + ', char: ' + char);

            //Password processing
            var count = password.split(char).length - 1;
            // Sys.println('count: ' + count);
            
            //solving a
            if (count >= min && count <= max) resultA++;

            //solving b
            if (password.charAt(min-1) == char && password.charAt(max-1) != char ||
                password.charAt(min-1) != char && password.charAt(max-1) == char) resultB++;

            // Sys.println('');
        }
        Sys.println('a: ' + resultA);
        Sys.println('b: ' + resultB);
    }
}