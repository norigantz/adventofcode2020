package solutions;

import cs.StdTypes.Int64;

class Day13 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day13.txt');

    public static function solve() {
        Sys.println("Solving Day13");
        var arr:Array<String> = input.split('\r\n');
        var arrivalAtStationTime = Std.parseInt(arr[0]);
        var busIds = arr[1].split(',').map(Std.parseInt);
        
        var nextBusId = 0;
        var nextBusTime = 999999999;
        for (busId in busIds) {
            if (busId == null) continue;
            var trips = Std.int(arrivalAtStationTime / busId);
            if ((trips * busId + busId) < nextBusTime) {
                nextBusTime = trips * busId + busId;
                nextBusId = busId;
            }
        }

        Sys.println('a: ' + nextBusId * (nextBusTime - arrivalAtStationTime));

        var busInts:Array<Int> = new Array<Int>();
        for (i in 0...busIds.length)
            busInts[i] = busIds[i];

        var currTime:Int64 = busInts[0];
        var iterator:Int64 = busInts[0];
        var busesFound:Array<Int> = [busIds[0]];
        while (true) {
            currTime += iterator;
            var allSequentialBuses = true;
            for (i in 0...busIds.length) {
                if (busIds[i] == null || busesFound.contains(busIds[i])) continue;
                if ((currTime + i) % busInts[i] == 0) {
                    busesFound.push(busInts[i]);
                    iterator *= busInts[i];
                }
                else {
                    allSequentialBuses = false;
                }
            }
            if (allSequentialBuses) break;
        }
        Sys.println('b: ' + currTime);
    }
}