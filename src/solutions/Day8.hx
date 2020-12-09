package solutions;

class Day8 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day8.txt');

    static var instructions:Array<String>;
    static var testNodes:Map<Int, Int> = new Map<Int, Int>();
    static var loopHistory:Array<Int> = new Array<Int>();
    static var loopEnd:Int = -1;

    public static function solve() {
        Sys.println("Solving Day8");
        instructions = input.split('\r\n');

        Sys.println('a: ' + runInstructions());

        for (key in testNodes.keys()) {
            var resultArr = findFault(key, testNodes[key]);
            if (resultArr[1] > -1) {
                Sys.println('b: ' + resultArr[0]);
                break;
            }
        }
    }

    static function runInstructions():Int {
        var index = 0;
        var accumulator = 0;
        var opArr:Array<Int>;
        var instructionArr:Array<String>;

        while (!loopHistory.contains(index)) {
            instructionArr = instructions[index].split(' ');
            loopHistory.push(index);
            if (instructionArr[0].indexOf('jmp') > -1 || instructionArr[0].indexOf('nop') > -1) testNodes[index] = accumulator;
            opArr = runOp(instructionArr, index, accumulator);
            index = opArr[0];
            accumulator = opArr[1];
        }
        loopEnd = index;
        return accumulator;
    }

    static function findFault(startIndex:Int, accumulator:Int):Array<Int> {
        var index = startIndex;
        var programTerminated = -1;
        var opArr:Array<Int>;
        var instructionArr:Array<String>;

        while (index != loopEnd) {
            if (index != startIndex && loopHistory.contains(index)) break;
            if (index == instructions.length) {
                programTerminated = 1;
                break;
            }
            instructionArr = instructions[index].split(' ');
            if (index == startIndex) {
                if (instructionArr[0].indexOf('jmp') > -1) instructionArr[0] = 'nop';
                else if (instructionArr[0].indexOf('nop') > -1) instructionArr[0] = 'jmp';
            }
            opArr = runOp(instructionArr, index, accumulator);
            index = opArr[0];
            accumulator = opArr[1];
        }
        return [accumulator, programTerminated];
    }

    static function runOp(op:Array<String>, index:Int, accumulator:Int):Array<Int> {
        switch (op[0]) {
            case "acc":
                accumulator += Std.parseInt(op[1]);
                index++;
            case "jmp":
                index += Std.parseInt(op[1]);
            case "nop":
                index++;
            default: Sys.println("Bad instruction");
        }
        return [index, accumulator];
    }
}