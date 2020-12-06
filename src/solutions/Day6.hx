package solutions;

class Day6 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day6.txt');

    public static function solve() {
        Sys.println("Solving Day6");
        var arr:Array<String> = input.split('\r\n\r\n');

        var resultA = 0;
        var resultB = 0;
        
        for (group in arr) {
            var personArr:Array<String> = group.split('\r\n');
            var groupString = "";
            var groupMap:Map<String, Int> = new Map<String, Int>();
            for (person in personArr) {
                for (answer in person) {
                    if (groupString.indexOf(""+answer) == -1) groupString += answer;
                    groupMap[""+answer]++;
                }
            }
            resultA = resultA == 0 ? groupString.length : resultA + groupString.length;
            for (key in groupMap.keys()) {
                if (groupMap[key] == personArr.length) resultB++;
            }            
        }

        Sys.println('a: ' + resultA);
        Sys.println('b: ' + resultB);
    }
}