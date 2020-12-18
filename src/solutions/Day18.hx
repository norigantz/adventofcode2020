package solutions;

import haxe.Int64;
using StringTools;

class Day18 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day18.txt');

    public static function solve() {
        Sys.println("Solving Day18");
        var arr:Array<String> = input.split('\r\n');

        var sum:Int64 = 0;
        for (i in 0...arr.length) {
            Sys.println(i + ': ' + arr[i]);
            if (evaluate(arr[i], '') < 0)
                break;
            sum += evaluate(arr[i], '');
        }
        Sys.println('a: ' + sum);
        // Sys.println(evaluate(arr[52]));
    }

    static function evaluate(expression:String, opPreference:String):Int64 {
        expression = expression.replace(' ', '');
        Sys.println(expression);

        var parens = 0;
        var subExpression = '';
        var ereg = ~/[(]/;
        while(ereg.match(expression)) {
            for (i in 0...expression.length) {
                if (expression.charAt(i) == '(')
                    parens++;
                if (parens > 0)
                    subExpression += expression.charAt(i);
                if (expression.charAt(i) == ')') {
                    parens--;
                    if(parens == 0) {
                        Sys.println(subExpression);
                        expression = expression.replace(subExpression, ''+evaluate(subExpression.substr(1, subExpression.length-2), ''));
                        Sys.println(expression);
                        subExpression = '';
                        break;
                    }
                }
            }
        }
        
        ereg = ~/[+*]/;
        var currExpression = expression;
        var result:Int64 = 0;
        while (ereg.match(currExpression)) {
            var left:Int64 = Int64.parseString(ereg.matchedLeft());
            var op = ereg.matched(0);
            var right:Int64;
            var rightReg = ~/[+*]/;
            if (rightReg.match(ereg.matchedRight()))
                right = Int64.parseString(rightReg.matchedLeft());
            else
                right = Int64.parseString(ereg.matchedRight());
            Sys.println(left);
            Sys.println(op);
            Sys.println(right);
            
            result = op == '+' ? left + right : left * right;
            Sys.println('='+result);
            Sys.println('');
            currExpression = result + currExpression.substr((left + op + right).length);
        }
        return result;
    }
}