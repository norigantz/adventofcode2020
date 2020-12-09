package solutions;

class Day8 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day8.txt');

    static var instructions:Array<String>;

    static var loopNodes:Map<Int, Int> = new Map<Int, Int>();

    static var loopEnd:Int = -1;

    public static function solve() {
        Sys.println("Solving Day8");
        instructions = input.split('\r\n');

        Sys.println('a: ' + runInstructions(0, 0, false)[0]);

        // for (i in 0...arr.length) {
        //     var resultArr = runInstructions(arr, 0, i);
        //     if (resultArr[1] > -1) {
        //         Sys.println('b: ' + resultArr[0]);
        //         break;
        //     }
        // }
        for (key in loopNodes.keys()) {
            // Sys.println(key + ', ' + loopNodes[key] + ', ' + loopEnd);
            var resultArr = runInstructions(key, loopNodes[key], true);
            // Sys.println(resultArr);
            if (resultArr[1] > -1) {
                Sys.println('b: ' + resultArr[0]);
                break;
            }
        }
    }

    static function runInstructions(startIndex:Int, accumulator:Int, flip:Bool):Array<Int> {
        var opPointer:Int = startIndex;
        var opHistory:Array<Int> = new Array<Int>();
        var programTerminated = -1;

        while (!opHistory.contains(opPointer)) {
            if (opPointer == instructions.length) {
                programTerminated = 1;
                break;
            }
            if (loopEnd > -1 && opPointer == loopEnd) {
                break;
            }
            var instructionArr = instructions[opPointer].split(' ');
            if (flip && opPointer == startIndex) {
                if (instructionArr[0].indexOf('jmp') > -1) instructionArr[0] = 'nop';
                else if (instructionArr[0].indexOf('nop') > -1) instructionArr[0] = 'jmp';
            }
            opHistory.push(opPointer);
            switch (instructionArr[0]) {
                case "acc":
                    accumulator += Std.parseInt(instructionArr[1]);
                    opPointer++;
                case "jmp":
                    if (startIndex == 0) loopNodes[opPointer] = accumulator;
                    opPointer += Std.parseInt(instructionArr[1]);
                case "nop":
                    if (startIndex == 0) loopNodes[opPointer] = accumulator;
                    opPointer++;
                default: Sys.println("Bad instruction");
            }
        }
        if (startIndex == 0 && programTerminated < 1) {
            loopEnd = opPointer;
        }
        return [accumulator, programTerminated];
    }

    static function findFault(startIndex:Int, accumulator:Int) {
        
    }
}