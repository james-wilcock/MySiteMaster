QUnit.test("hello test", function (assert) {
    assert.ok(1 == "1", "Passed!");
});

//QUnit.test("dom elements", function (assert) {
   

//    var map = document.getElementsByClassName('map');
//    assert.equal(map[0], undefined);

//});

QUnit.test("test pathToFile", function (assert) {    
    var x = pathToFile("\\Pictures/image1.jpg");
    assert.equal(x.name, "image1");
});


//QUnit.test("test map load", function (assert) {
//    var map = initMap();
//    assert.notEqual(map, undefined);
//});


