package solutions;

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
            var password = lineArr[1]; //could use StringTools.trim() here: put "using StringTools" above and then add ".trim()" to this String
            // Sys.println(policy + ', ' + password);

            //Policy processing
            var minMaxArr = policy.split('-');
            var min = Std.parseInt(minMaxArr[0]);
            var maxCharArr = minMaxArr[1].split(' ');
            var max = Std.parseInt(maxCharArr[0]);
            var char = maxCharArr[1];
            // Sys.println('min: ' + min + ', max: ' + max + ', char: ' + char);

            //Password processing
            var count = password.split(char).length - 1;
            // Sys.println('count: ' + count);
            
            //solving a
            if (count >= min && count <= max) resultA++;

            //solving b; does not do -1 on the charAt's because there is a leading space in the password
            if (password.charAt(min) == char && password.charAt(max) != char ||
                password.charAt(min) != char && password.charAt(max) == char) resultB++;

            // Sys.println('');
        }
        Sys.println('a: ' + resultA);
        Sys.println('b: ' + resultB);
    }
}