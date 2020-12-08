package solutions;

class Day8 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day8.txt');

    public static function solve() {
        Sys.println("Solving Day8");
        var arr:Array<String> = input.split('\r\n');

        Sys.println('a: ' + runInstructions(arr, -1)[0]);

        for (i in 0...arr.length) {
            var resultArr = runInstructions(arr, i);
            if (resultArr[1] > -1) {
                Sys.println('b: ' + resultArr[0]);
                break;
            }
        }
    }

    static function runInstructions(instructions:Array<String>, flipPointer:Int):Array<Int> {
        var opPointer:Int = 0;
        var opHistory:Array<Int> = new Array<Int>();
        var accumulator:Int = 0;
        var programTerminated = -1;

        while (!opHistory.contains(opPointer)) {
            if (opPointer == instructions.length) {
                programTerminated = 1;
                break;
            }
            var instructionArr = instructions[opPointer].split(' ');
            if (opPointer == flipPointer) {
                if (instructionArr[0].indexOf('jmp') > -1) instructionArr[0] = 'nop';
                else if (instructionArr[0].indexOf('nop') > -1) instructionArr[0] = 'jmp';
            }
            opHistory.push(opPointer);
            switch (instructionArr[0]) {
                case "acc":
                    accumulator += Std.parseInt(instructionArr[1]);
                    opPointer++;
                case "jmp": 
                    opPointer += Std.parseInt(instructionArr[1]);
                case "nop": 
                    opPointer++;
                default: Sys.println("Bad instruction");
            }
        }
        return [accumulator, programTerminated];
    }
}