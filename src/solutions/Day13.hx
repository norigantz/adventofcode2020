package solutions;

import cs.StdTypes.Int64;

class Day13 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day13Example6.txt');

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
        for (i in 0...busIds.length) {
            busInts[i] = busIds[i];
        }
        Sys.println(busInts);

        // Sys.println(1068781 % 59 == 59 - 4);

        var currTime:Int64 = busInts[0];
        var iterator:Int64 = busInts[0];
        var busesFound:Array<Int> = [busIds[0]];
        var printer:Int64 = 0;
        while (true) {
            currTime += iterator;
            if (printer++ % 1000000 == 0) {
                Sys.println(currTime);
            }
            var allSequentialBuses = true;
            for (i in 0...busIds.length) {
                if (busIds[i] == null || busesFound.contains(busIds[i])) continue;
                // if (printer % 1000000 == 0) Sys.println(currTime % busInts[i]);
                if (currTime % busInts[i] == busInts[i] - i) {
                    busesFound.push(busInts[i]);
                    // iterator *= busInts[i];
                    Sys.println(busesFound + ', ' + iterator + ', ' + currTime);
                }
                else {
                    allSequentialBuses = false;
                }
            }
            if (allSequentialBuses) break;
        }
        Sys.println(currTime);

        for (i in 0...100) {
            if ((7 * i) % 19 == 12) Sys.println(7*i + ', ' + (7 * i) % 19);
        }
    }

    static function gcd(a:Int, b:Int):Int {
        if (b==0) return a;
        return gcd(b, a%b);
    }

    static function lcm(a:Int, b:Int):Int {
        return (Std.int(a / gcd(a, b)) * b);
    }
}