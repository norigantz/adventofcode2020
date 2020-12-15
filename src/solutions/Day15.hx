package solutions;

class Day15 {
    // static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day15.txt');
    static var input:Array<Int> = [0,3,1,6,7,5];
    static var inputEx1:Array<Int> = [0,3,6];

    public static function solve() {
        Sys.println("Solving Day15");
        var arr:Array<Int> = input;

        var numPlaces:Map<Int, Int> = new Map<Int, Int>();
        var numCount = 0;
        var lastNumber = arr[0];
        while (numCount < 2020-1) {
            Sys.println(lastNumber);
            if (numCount < arr.length) {
                numPlaces[lastNumber] = numCount;
                numCount++;
                lastNumber = arr[numCount];
            }
            else if (numPlaces[lastNumber] == null) {
                numPlaces[lastNumber] = numCount;
                numCount++;
                lastNumber = 0;
            }
            else {
                var diff = numCount - numPlaces[lastNumber];
                numPlaces[lastNumber] = numCount;
                numCount++;
                lastNumber = diff;
            }
        }
        Sys.println('a: ' + lastNumber);
    }
}