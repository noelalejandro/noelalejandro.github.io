// shapes
let circles = [];
let squares = [];
let stars = [];
let triangles = [];

// forces
let gravity = 0.9;
let wind = 0.0;

// synth parameters
let env;
let osc;
let delay;

// envelope parameters 
let t1 = 0.01; // attack time in seconds
let l1 = 0.7; // attack level 0.0 to 1.0
let t2 = 0.1; // decay time in seconds
let l2 = 0.0; // decay level  0.0 to 1.0

function setup() {
  createCanvas(windowWidth, windowHeight);
  background(0);
  
  // currently set to 1 shape each, this can be changed to any number
  for (let i = 0; i < 1; i++) {
    circles.push(new Circle());
    squares.push(new Square());
    stars.push(new Star());
    triangles.push(new Triangle());
  }

  // set up oscillator
  env = new p5.Envelope(t1, l1, t2, l2);
  osc = new p5.Oscillator();
  osc.amp(0.5);

  // set up delay
  delay = new p5.Delay();
  delay.process(osc, 0.99, 0.7, 750); // (input, delay time, feedback, filter cutoff)
  delay.setType('pingPong')
}

function windowResize() {
  resizeCanvas(windowWidth, windowHeight);
  background(0);
}

function playSound() {
  osc.start();
  env.play(osc);
}

function keyTyped() {
  // circles
  if (key === 's') {
    for (let i = 0; i < circles.length; i++) {
      circles[i].move();
      circles[i].display();
  
      // x postion determines oscillator frequency
      let freq = map(circles[i].x, 0, width, 110, 440);
      osc.freq(freq);
    }
  }

  // squares
  if (key === 'q') {
    for (let i = 0; i < squares.length; i++) {
      squares[i].move();
      squares[i].display();
  
      // x postion determines oscillator frequency
      let freq = map(squares[i].x, 0, width, 110, 440);
      osc.freq(freq);
    }
  }

  // stars
  if (key === 'w') {
    for (let i = 0; i < stars.length; i++) {
      stars[i].move();
      stars[i].display();
  
      // x postion determines oscillator frequency
      let freq = map(stars[i].x, 0, width, 110, 440);
      osc.freq(freq);
    }
  }

  // triangles
  if (key === 'a') {
    for (let i = 0; i < triangles.length; i++) {
      triangles[i].move();
      triangles[i].display();
  
      // x postion determines oscillator frequency
      let freq = map(triangles[i].x, 0, width, 110, 440);
      osc.freq(freq);
    }
  }
}

function draw() {
  background(0,0,0,30);

  // user instructions
  textSize(56);
  strokeWeight(1);
  stroke(100,100,100,50);
  text("use arrow keys to move around", width/4 -25, height - 50);
  text("A = triangle", 30, 60);
  text("Q = square", 30, 120);
  text("W = sawtooth", 30, 180);
  text("S = sine", 30, 240);

  noFill();
  strokeWeight(5);
  stroke(255);

  keyTyped();

  // user interactivity
  if (keyIsDown(UP_ARROW)) {
    gravity = gravity - 0.05;
    keyTyped();
  }
  if (keyIsDown(DOWN_ARROW)){
    gravity = gravity + 0.05;
    keyTyped();
  }
  if (keyIsDown(LEFT_ARROW)){
    wind = wind - 0.05;
    keyTyped();
  }
  if (keyIsDown(RIGHT_ARROW)){
    wind = wind + 0.05;
    keyTyped();
  }
}

// circle class
class Circle {
  constructor() {
    this.x = random(width); // position
    this.y = random(height); // position
    this.dx = random(-5,5); // velocity
    this.dy = 5; // velocity
    this.r = 75; // radius
    this.bounciness = 0.5;
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;

    // boundary collision
    // upper boundary
    if (this.y - this.r < 0) 
        {
            this.y = this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('sine');
            playSound();
        }

    // lower boundary
    if (this.y - this.r > windowHeight) 
        {
            this.y = windowHeight - this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('sine');
            playSound();
        }

    // left boundary
    if (this.x - this.r < 0) 
        {
            this.x = this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('sine');
            playSound();
        } 
    
    // right boundary
    if (this.x - this.r > windowWidth) 
        {
            this.x = windowWidth - this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('sine');
            playSound();
        }
    }

  display() {
    ellipse(this.x, this.y, this.r * 2, this.r * 2);
  }
}

// square class
class Square {
  constructor() {
    this.x = random(width); // position
    this.y = random(height); // position
    this.dx = random(-5,5); // velocity
    this.dy = 5; // velocity
    this.s = 150; // side length
    this.bounciness = 0.5;
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;

    // boundary collision
    // upper boundary
    if (this.y - this.s/32 < 0) 
        {
            this.y = this.s/32;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('square');
            playSound();
        }

    // lower boundary
    if (this.y + this.s > windowHeight) 
        {
            this.y = windowHeight - this.s;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('square');
            playSound();
        }

    // left boundary
    if (this.x - this.s/32 < 0) 
        {
            this.x = this.s/32;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('square');
            playSound();
        } 
    
    // right boundary
    if (this.x + this.s > windowWidth) 
        {
            this.x = windowWidth - this.s;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('square');
            playSound();
        }
    }

  display() {
    square(this.x, this.y, this.s);
  }
}

// star class
class Star {
  constructor() {
    this.x = random(width); // position
    this.y = random(height); // position
    this.dx = random(-5,5); // velocity
    this.dy = 5; // velocity
    this.r = 75; // side length
    this.bounciness = 0.5;
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;

    // boundary collision
    // upper boundary
    if (this.y - this.r < 0) 
        {
            this.y = this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('sawtooth');
            playSound();
        }

    // lower boundary
    if (this.y - this.r > windowHeight) 
        {
            this.y = windowHeight - this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('sawtooth');
            playSound();
        }

    // left boundary
    if (this.x - this.r < 0) 
        {
            this.x = this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('sawtooth');
            playSound();
        } 
    
    // right boundary
    if (this.x - this.r > windowWidth) 
        {
            this.x = windowWidth - this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('sawtooth');
            playSound();
        }
    }

  display() {
    let angle = TWO_PI / 5;
    let halfAngle = angle / 2.0;
    beginShape();
    for (let a = 0; a < TWO_PI; a += angle) {
      let sx = this.x + cos(a) * 30;
      let sy = this.y + sin(a) * 30;
      vertex(sx, sy);
      sx = this.x + cos(a + halfAngle) * this.r;
      sy = this.y + sin(a + halfAngle) * this.r;
      vertex(sx, sy);
    }
    endShape(CLOSE);
  }
}

// triangle class
class Triangle {
  constructor() {
    this.x = random(width); // position
    this.y = random(height); // position
    this.dx = random(-5,5); // velocity
    this.dy = 5; // velocity
    this.r = 85; // side length
    this.bounciness = 0.5;
  }

  move() {
    this.x += this.dx;
    this.y += this.dy;
    this.dx += wind;
    this.dy += gravity;

    // boundary collision
    // upper boundary
    if (this.y - this.r < 0) 
        {
            this.y = this.r;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('triangle');
            playSound();
        }

    // lower boundary
    if (this.y - this.r/2 > windowHeight) 
        {
            this.y = windowHeight - this.r/2;
            this.dy = this.dy * -1 * this.bounciness;

            // trigger synth
            osc.setType('triangle');
            playSound();
        }

    // left boundary
    if (this.x - this.r < 0) 
        {
            this.x = this.r;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('triangle');
            playSound();
        } 
    
    // right boundary
    if (this.x - this.r/2 > windowWidth) 
        {
            this.x = windowWidth - this.r/2;
            this.dx = this.dx * -1 * this.bounciness;

            // trigger synth
            osc.setType('triangle');
            playSound();
        }
    }

  display() {
    let angle = TWO_PI / 3.0;
    let halfAngle = angle / 2.0;
    beginShape();
    for (let a = 0; a < TWO_PI; a += angle) {
      let sx = this.x + cos(a) * 42;
      let sy = this.y + sin(a) * 42;
      vertex(sx, sy);
      sx = this.x + cos(a + halfAngle) * this.r;
      sy = this.y + sin(a + halfAngle) * this.r;
      vertex(sx, sy);
    }
    endShape(CLOSE);
  }
}
