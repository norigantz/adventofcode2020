package solutions;

import haxe.Int64;

class Day9 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day9.txt');

    static var arr:Array<Int64> = input.split('\r\n').map(Int64.parseString);
    static var preambleLength = 25;

    public static function solve() {
        Sys.println("Solving Day9");
        var testValue:Int64 = 0;

        for (i in preambleLength...arr.length) {
            testValue = arr[i];
            if (!sumExists(testValue, i)) {
                Sys.println('a: ' + testValue);
                var resultBArr = findContiguousSum(testValue);
                var resultB = resultBArr[0] + resultBArr[1];
                Sys.println('b: ' + resultB);
                break;
            }
        }
    }

    static function sumExists(targetValue:Int64, targetIndex:Int):Bool {
        var startIndex = targetIndex - preambleLength;
        for (i in startIndex...targetIndex) {
            for (j in (i+1)...targetIndex) {
                if (arr[i] + arr[j] == targetValue) return true;
            }
        }
        return false;
    }

    static function findContiguousSum(value:Int64):Array<Int64> {
        var rangeStart = 0, rangeEnd = 0;
        var overshot;
        for (i in 0...arr.length) {
            overshot = false;
            if (arr[i] == value) continue;
            for (j in i+1...arr.length) {
                if(overshot) break;
                var currSum:Int64 = 0;
                for (k in i...j-1) {
                    currSum += arr[k];
                    if (currSum == value) {
                        rangeStart = i;
                        rangeEnd = k;
                    }
                    else if (currSum > value) {
                        overshot = true;
                        break;
                    }
                }
            }
        }
        var min = arr[rangeStart];
        var max = arr[rangeStart];
        for (i in rangeStart...rangeEnd) {
            if (arr[i] < min) min = arr[i];
            if (arr[i] > max) max = arr[i];
        }
        return [min, max];
    }
}