package solutions;
import haxe.Int64;
using StringTools;

class Day7 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day7.txt');

    static var bagMap:Map<String, String>;

    public static function solve() {
        Sys.println("Solving Day7");
        var arr:Array<String> = input.split('\r\n');

        bagMap = new Map<String, String>();
        for (rule in arr) {
            var ruleSplit = rule.split('contain');
            bagMap[ruleSplit[0].split('bags')[0].rtrim()] = ruleSplit[1];
        }
        
        Sys.println('a: ' + matchBags('shiny gold', new Array<String>(), 0));
        Sys.println('b: ' + countBags('shiny gold', 1));
    }

    static function matchBags(bagName:String, checkedBags:Array<String>, depth:Int):Int {
        var count = 0;
        for (bagKey in bagMap.keys()) {
            if (!checkedBags.contains(bagKey) && bagMap[bagKey].indexOf(bagName) > -1) {
                count += 1 + matchBags(bagKey, checkedBags, ++depth);
                checkedBags.push(bagKey);
            }
        }
        return count;
    }

    static function countBags(bagName:String, multiplier:Int):Int {
        var count = 0;

        var bagRegex = ~/(bag)s?,?/;
        var childBagArr = [];
        var input = bagMap[bagName];
        while (bagRegex.match(input)) {
            var curr = bagRegex.matchedLeft().trim();
            if (curr.indexOf('other') > -1) break;
            childBagArr.push(curr);
            input = bagRegex.matchedRight();
        }

        for (bag in childBagArr) {
            var value = Std.parseInt(bag.charAt(0)); //assumes the value is < 10
            count += multiplier * value;
            count += countBags(bag.substr(2), multiplier * value);
        }

        return count;
    }
}