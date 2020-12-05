package solutions;

class Day5 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day5.txt');

    static var seatExists:Array<Bool> = [];

    public static function solve() {
        Sys.println("Solving Day5");
        var arr:Array<String> = input.split('\r\n');

        seatExists.resize(1023);

        var maxPass = 0;
        for (pass in arr) {
            var curr = processBoardingPass(pass);
            if (curr > maxPass) maxPass = curr;
        }
        Sys.println('a: ' + maxPass);

        for (i in 1...1023) {
            if (!seatExists[i] && seatExists[i-1] && seatExists[i+1]) {
                Sys.println('b: ' + i);
                return;
            }
        }
    }

    static function processBoardingPass(pass:String):Int {
        var rowRange:Array<Int> = [0, 127];
        var power = 64;
        for (i in 0...7) {
            if (pass.charAt(i) == 'F') rowRange = [rowRange[0], rowRange[1] - power];
            else rowRange = [rowRange[0] + power, rowRange[1]];
            power >>= 1;
        }

        var colRange:Array<Int> = [0, 7];
        power = 4;
        for (i in 7...10) {
            if (pass.charAt(i) == 'L') colRange = [colRange[0], colRange[1] - power];
            else colRange = [colRange[0] + power, colRange[1]];
            power >>= 1;
        }

        var id = rowRange[0] * 8 + colRange[0];
        seatExists[id] = true;
        return id;
    }
}