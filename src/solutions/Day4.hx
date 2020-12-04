package solutions;

class Day4 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day4.txt');
    
    static var required:Array<String> = ['byr', 'iyr', 'eyr', 'hgt', 'hcl', 'ecl', 'pid'];

    public static function solve() {
        Sys.println("Solving Day4");
        var arr:Array<String> = input.split('\r\n\r\n');
        
        var resultA = 0;
        var resultB = 0;
        for (passport in arr) {
            var keyValues:Map<String, String> = processPassport(passport);

            if (hasRequiredFields(keyValues)) {
                resultA++;
                if (hasValidValues(keyValues)) resultB++;
            }
        }
        
        Sys.println("a: " + resultA);
        Sys.println("b: " + resultB);
    }

    static function processPassport(passport:String):Map<String, String> {
        var fields:Array<String> = ~/[ ]|\r\n/g.split(passport);
        var keyValues:Map<String, String> = new Map<String, String>();
        for (field in fields) {
            keyValues[field.substr(0, 3)] = field.substr(4, field.length-4);
        }
        return keyValues;
    }

    static function hasRequiredFields(keyValues:Map<String, String>):Bool {
        for (requirement in required) if (!keyValues.exists(requirement)) return false;
        return true;
    }

    static function hasValidValues(keyValues:Map<String, String>):Bool {
        for (key in keyValues.keys()) if (!isFieldValid(key, keyValues[key])) return false;
        return true;
    }

    static function isFieldValid(key:String, value:String):Bool {
        switch (key) {
            case 'byr':
                var numVal = Std.parseInt(value);
                return value.length == 4 && numVal >= 1920 && numVal <= 2002;
            case 'iyr':
                var numVal = Std.parseInt(value);
                return value.length == 4 && numVal >= 2010 && numVal <= 2020;
            case 'eyr':
                var numVal = Std.parseInt(value);
                return value.length == 4 && numVal >= 2020 && numVal <= 2030;
            case 'hgt':
                var numVal = Std.parseInt(value);
                if (~/(cm)/.match(value)) return numVal >= 150 && numVal <= 193;
                else if (~/(in)/.match(value)) return numVal >= 59 && numVal <= 76;
            case 'hcl': if (value.charAt(0) == '#' && value.length == 7) return ~/[0-9]|[a-f]/.match(value);
            case 'ecl': return ~/(amb)|(blu)|(brn)|(gry)|(grn)|(hzl)|(oth)/.match(value);
            case 'pid': if (value.length == 9) return ~/[0-9]/.match(value);
            case 'cid': return true;
            default: Sys.println("Bad key provided to validator");
        }
        return false;
    }
}