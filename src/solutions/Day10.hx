package solutions;

class Day10 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day10.txt');

    public static function solve() {
        Sys.println("Solving Day10");
        var arr:Array<Int> = input.split('\r\n').map(Std.parseInt);
        var joltageDiffs:Map<Int, Int> = new Map<Int, Int>();
        var diffSequence:Array<Int> = new Array<Int>();
        arr.sort((a, b) -> a - b);
        var deviceJoltage = arr[arr.length-1] + 3;

        joltageDiffs[arr[0]]++;
        diffSequence.push(arr[0]);
        for (i in 1...arr.length) {
            var diff = arr[i] - arr[i-1];
            joltageDiffs[diff]++;
            diffSequence.push(diff);
        }
        joltageDiffs[deviceJoltage - arr[arr.length-1]]++;
        Sys.println('a: ' + joltageDiffs[1] * joltageDiffs[3]);

        var lengthsOfRemovableOnes:Array<Int> = new Array<Int>();
        var oneCounter = 0;
        for (i in 0...diffSequence.length) {
            if (diffSequence[i] == 1) oneCounter++;
            if (diffSequence[i] == 3) {
                if (oneCounter > 1) lengthsOfRemovableOnes.push(oneCounter-1);
                oneCounter = 0;
            }
            else if (i + 1 >= diffSequence.length && oneCounter > 1) lengthsOfRemovableOnes.push(oneCounter-1);
        }

        var resultB = 1.0;
        for (length in lengthsOfRemovableOnes) {
            switch (length) {
                case 1: resultB *= 2;
                case 2: resultB *= 4;
                case 3: resultB *= 7;
                default: Sys.println("Unhandled length in lengthsOfRemovableOnes");
            }
        }
        Sys.println('b: ' + resultB);
    }
}