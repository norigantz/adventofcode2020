package solutions;

import haxe.Int64;
using StringTools;

class Day16 {
    static var input:String = sys.io.File.getContent('E:/Mila/Documents/GitHub/adventofcode2020/src/inputs/Day16.txt');

    static var nearbyTickets:Array<Array<Int>> = new Array<Array<Int>>();

    public static function solve() {
        Sys.println("Solving Day16");
        
        var fieldRulesStr:Array<String> = input.split('your ticket:')[0].split('\r\n');
        fieldRulesStr.remove('');
        fieldRulesStr.remove('');
        var fieldRules:Map<String, Array<Int>> = new Map<String, Array<Int>>();
        for (line in fieldRulesStr) {
            var lineArr = line.split(':');
            var fieldName = lineArr[0];
            var rulesArr = lineArr[1].split('or');
            var lowRangeStr = rulesArr[0].split('-');
            lowRangeStr[0] = lowRangeStr[0].trim();
            lowRangeStr[1] = lowRangeStr[1].trim();
            var lowRange = lowRangeStr.map(Std.parseInt);
            var highRange = rulesArr[1].split('-').map(Std.parseInt);
            fieldRules[fieldName] = lowRange.concat(highRange);
        }
        var nearbyTicketsStr:Array<String> = input.split('nearby tickets:')[1].split('\r\n');
        nearbyTicketsStr.remove('');
        for (ticket in nearbyTicketsStr)
            nearbyTickets.push(ticket.split(',').map(Std.parseInt));

        Sys.println('a: ' + calcTicketScanErrorRate(fieldRules, nearbyTickets));

        var orderedFields = determineFieldOrder(fieldRules, nearbyTickets);
        var resultB:Int64 = 1;
        var myTicket = input.split('your ticket:')[1].split('\r\n')[1].split(',').map(Std.parseInt);
        for (i in 0...myTicket.length) {
            if (orderedFields[i].indexOf("departure") == 0) resultB *= myTicket[i];
        }
        Sys.println('b: ' + resultB);
    }

    static function determineFieldOrder(fieldRules:Map<String, Array<Int>>, tickets:Array<Array<Int>>):Array<String> {
        var orderedFields = [];
        var allFields:Array<String> = new Array<String>();
        for (key in fieldRules.keys())
            allFields.push(key);
        var currValidFields:Array<Array<String>> = new Array<Array<String>>(); //each row is a field, each column a potential choice of field
        for (i in 0...allFields.length)
            currValidFields.push(allFields.copy());
        var unsolvedRows:Array<Int> = new Array<Int>();
        while(unsolvedRows.length < currValidFields.length) {
            for (t in 0...tickets.length) {
                for (i in 0...tickets[t].length) {
                    for (field in currValidFields[i]) {
                        if (tickets[t][i] < fieldRules[field][0] || tickets[t][i] > fieldRules[field][3] || (tickets[t][i] > fieldRules[field][1] && tickets[t][i] < fieldRules[field][2])) currValidFields[i].remove(field);
                    }
                }
            }
            for (i in 0...currValidFields.length) {
                if (!unsolvedRows.contains(i) && currValidFields[i].length == 1) {
                    unsolvedRows.push(i);
                    for (j in 0...currValidFields.length)
                        if (i != j) currValidFields[j].remove(currValidFields[i][0]);
                }
            }
        }
        
        for (row in currValidFields)
            orderedFields.push(row[0]);
        return orderedFields;
    }

    static function calcTicketScanErrorRate(fieldRules:Map<String, Array<Int>>, tickets:Array<Array<Int>>):Int {
        var errorSum = 0;
        var badTickets:Array<Int> = new Array<Int>();
        for (i in 0...tickets.length) {
            for (value in tickets[i]) {
                var isValid = false;
                for (field in fieldRules.keys()) {
                    if ((value >= fieldRules[field][0] && value <= fieldRules[field][1]) || (value >= fieldRules[field][2] && value <= fieldRules[field][3])) {
                        isValid = true;
                        break;
                    }
                }
                if (!isValid) {
                    errorSum += value;
                    badTickets.push(i);
                }
            }
        }
        var validTickets:Array<Array<Int>> = new Array<Array<Int>>();
        for (i in 0...nearbyTickets.length) {
            if (!badTickets.contains(i))
                validTickets.push(nearbyTickets[i]);
        }
        nearbyTickets = validTickets;
        return errorSum;
    }

}