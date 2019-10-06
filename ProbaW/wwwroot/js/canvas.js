var canvas = document.getElementById("myCanvas");
var ctx = canvas.getContext("2d");


/*
ctx.moveTo(0, 0);
ctx.lineTo(200, 100);
ctx.stroke();
*/
backgroundImage=new Image();
backgroundImage.ready=false;
backgroundImage.onload=checkReady;
backgroundImage.src="images/raskrsnica.jpg";
mainImage=new Image();
mainImage.ready=false;
mainImage.onload=checkReady;
mainImage.src="images/ambulance.png";
var player={
	x:80,
	y:140,
	speed:6
}

var keyclick={};
let counterZaIzlazakSaUlice = 0;
document.addEventListener("keydown",function(event){
	keyclick[event.keyCode]=true;
	move(keyclick);
},false);
	document.addEventListener("keyup",function(event){
	delete keyclick[event.keyCode]
	
},false);
window.addEventListener("keydown", function(e) {
    // space and arrow keys
    if([32, 37, 38, 39, 40].indexOf(e.keyCode) > -1) {
        e.preventDefault();
    }
}, false);

function move(keyclick)
{
	// let counterZaIzlazakSaUlice = 0;
	if (37 in keyclick){player.x -=player.speed;}
    if (39 in keyclick) {player.x +=player.speed; }     
    if (38 in keyclick) { player.y -=player.speed;}    
    if (40 in keyclick) {player.y +=player.speed; } 
	// width
	console.log('width CANVASA', canvas.width)
	// provera za kounter
	if (counterZaIzlazakSaUlice > 2) {
		alert("Drive careful");
		player.x=80;
		player.y=140;
		window.location.reload();
	}
	if(player.x >=450) {
		
		player.x=50;
	} 
	if(player.x<50){player.x = 450}
	// height
	console.log('HEIGHT CANVASA', canvas.height)
	if(player.y >=180 && (player.x < 266 || player.x > 296)) {
		player.y=20;
		counterZaIzlazakSaUlice++
	}
	if(player.y<120 && (player.x < 266 || player.x > 296)) {
		player.y =140;
		counterZaIzlazakSaUlice++
	}
	// ogranizenje da ne bi izlazio iz canvasa
	if (player.y <8 || player.y > 260) {
		player.y = 146;
	}
	console.log(player.x, player.y);
	render();
}

function checkReady()
{
	this.ready=true;
	playgame();
}
function playgame()
{
	
	render();
}
function render()
{
	/*ctx.fillStyle="white";*/
	 
	//ctx.fillStyle ="url('C:\\Users\\Owner\\Desktop\\WebSite-box-V3.2\\WebSite-box-V3.2\\images\\raskrsnica.jpg')";
	//ctx.fillStyle = "url('C:\Users\Owner\Desktop\WebSite-box-V3.2\WebSite-box-V3.2\images\raskrsnica.jpg')";
	//ctx.backgroundImage = "url('C:\\Users\Owner\Desktop\WebSite-box-V3.2\WebSite-box-V3.2\images\raskrsnica.jpg')";
	//document.getElementById("myCanvas").style.backgroundImage = "url('C:\\Users\\Owner\\Desktop\\WebSite-box-V3.2\\WebSite-box-V3.2\\images\\raskrsnica.jpg')";
	
	ctx.fillRect(0,0,canvas.width,canvas.height);
	ctx.drawImage(backgroundImage, 10, 10);	
	ctx.drawImage(mainImage,player.x,player.y,20,20);
	
}