var stage;
var queue;
function init() {
    var boardContainer = document.getElementById("board-container");
    stage = new createjs.Stage("board-canvas");
    stage.canvas.width = boardContainer.offsetWidth;
    stage.canvas.height = boardContainer.offsetHeight;
    queue = new createjs.LoadQueue();
    queue.on("complete", handleComplete, this);
    queue.loadManifest([
        { id: "sea", src: "img/sea.svg", type: createjs.LoadQueue.IMAGE }
    ]);
}

function handleComplete() {
    setBackground();
}

function setBackground() {
    var img = queue.getResult("sea");
    var bitmap = new createjs.Bitmap(img);
    var canvasWidth = stage.canvas.width;
    var canvasHeight = stage.canvas.height;

    bitmap.scaleX = canvasWidth / img.width;
    bitmap.scaleY = canvasHeight / img.height;
    bitmap.width = canvasWidth;
    bitmap.height = canvasHeight;

    stage.addChild(bitmap);
    stage.update();
}