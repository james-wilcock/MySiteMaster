QUnit.test("hello test", function (assert) {
    assert.ok(1 == "1", "Passed!");
});
QUnit.test("prettydate basics", function (assert) {
    var now = "2008/01/28 22:25:00";
    assert.equal(now, "2008/01/28 22:24:30");
    
});