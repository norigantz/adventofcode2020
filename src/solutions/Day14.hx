package solutions;

import haxe.Int64;
using StringTools;

class Day14 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day14.txt');

    static var arr:Array<String> = input.split('\r\n');
    static var memory:Map<String, Int64> = new Map<String, Int64>();

    public static function solve() {
        Sys.println("Solving Day14");
        
        decoderV1();
        memory.clear();
        decoderV2();
    }

    static function decoderV2() {
        var mask:String = "";
        for (line in arr) {
            var lineArr = line.split('=');
            var instruct = lineArr[0].rtrim();
            if (instruct == "mask") {
                mask = lineArr[1].ltrim();
            }
            else if (instruct.substr(0, 3) == "mem") {
                var addr = instruct.split('[')[1];
                var parsedAddress = Std.int(Std.parseInt(addr.substr(0, addr.length-1)));
                var writeAddresses = applyMaskToAddress(mask, parsedAddress);
                for (address in writeAddresses)
                    memory[address] = Std.parseInt(lineArr[1].ltrim());
            }
        }
        var sum:Int64 = 0;
        for (key in memory.keys()) {
            sum += memory.get(key);
        }
        Sys.println('b: ' + sum);
    }

    static function applyMaskToAddress(mask:String, address:Int):Array<String> {
        var initialOutputAddress:Int64 = address;
        var floatingBits:Array<Int> = new Array<Int>();
        var currBit = 0;
        var one:Int64 = 1;
        while (currBit < mask.length) {
            switch (mask.charAt(mask.length-1-currBit)) {
                case 'X':
                    floatingBits.push(currBit);
                case '0':
                case '1':
                    initialOutputAddress |= one<<currBit;
                default: Sys.println("Unhandled bitmask character in applyMask()");
            }
            currBit++;
        }
        var writeAddresses:Array<String> = new Array<String>();
        var newAddress:Int64;
        var floatingMask:Int64 = 0;
        while (floatingMask < Math.pow(2, floatingBits.length)) {
            newAddress = initialOutputAddress;
            for (i in 0...floatingBits.length) {
                if (floatingMask & (one<<i) > 0)
                    newAddress |= one<<floatingBits[i];
                else
                    newAddress &= ~(one<<floatingBits[i]);
            }
            writeAddresses.push(""+newAddress);
            floatingMask++;
        }
        return writeAddresses;
    }

    static function decoderV1() {
        var mask:String = "";
        for (line in arr) {
            var lineArr = line.split('=');
            var instruct = lineArr[0].rtrim();
            if (instruct == "mask") {
                mask = lineArr[1].ltrim();
            }
            else if (instruct.substr(0, 3) == "mem") {
                var addr = instruct.split('[')[1];
                memory[addr.substr(0, addr.length-1)] = applyMaskToValue(mask, Std.parseInt(lineArr[1].ltrim()));
            }
        }
        var sum:Int64 = 0;
        for (key in memory.keys()) {
            sum += memory.get(key);
        }
        Sys.println('a: ' + sum);
    }

    static function applyMaskToValue(mask:String, value:Int64) {
        var output:Int64 = value;
        var currBit = 0;
        var one:Int64 = 1;
        while (currBit < mask.length) {
            switch (mask.charAt(mask.length-1-currBit)) {
                case 'X':
                case '0':
                    output &= ~(one<<currBit);
                case '1':
                    output |= one<<currBit;
                default: Sys.println("Unhandled bitmask character in applyMask()");
            }
            currBit++;
        }
        return output;
    }
}