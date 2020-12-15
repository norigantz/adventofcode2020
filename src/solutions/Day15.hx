package solutions;

class Day15 {
    static var input:Array<Int> = [0,3,1,6,7,5];
    static var inputEx1:Array<Int> = [0,3,6];

    public static function solve() {
        Sys.println("Solving Day15");
        var arr:Array<Int> = input;

        Sys.println('a: ' + runGameFast(arr, 2020));
        Sys.println('b: ' + runGameFast(arr, 30000000));
    }

    static function runGameFast(arr:Array<Int>, loops:Int):Int {
        var numAges:Array<Null<Int>> = new Array<Null<Int>>();
        numAges.resize(loops);
        var numCount = 0;
        var lastNumber = arr[0];
        while (numCount < loops-1) {
            if (numCount < arr.length) {
                numAges[lastNumber] = numCount;
                numCount++;
                lastNumber = arr[numCount];
            }
            else if (numAges[lastNumber] == null) {
                numAges[lastNumber] = numCount;
                numCount++;
                lastNumber = 0;
            }
            else {
                var diff = numCount - numAges[lastNumber];
                numAges[lastNumber] = numCount;
                numCount++;
                lastNumber = diff;
            }
        }
        return lastNumber;
    }
}