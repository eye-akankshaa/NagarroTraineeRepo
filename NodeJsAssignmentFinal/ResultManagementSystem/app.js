const express = require("express");
const dotenv = require("dotenv");
//used for logging all requests
const logger = require("morgan");

const cookieParser = require("cookie-parser");
const mongoose = require("mongoose");

// intialising app variable as express application
const app = express();

dotenv.config({ path: "config.env" });

//if the variable of this default app is not available we will use port 8080
const PORT = process.env.PORT || 8080;

//log requests
app.use(logger("tiny"));

//mongodb connection
mongoose.connect(
  "mongodb+srv://akanshamongoDb:shubhi123@cluster0.tzg41jq.mongodb.net/?retryWrites=true&w=majority",
  {
    useNewUrlParser: true,
    useUnifiedTopology: true,
  }
);

const db = mongoose.connection;
db.on("error", console.error.bind(console, "connection error: "));
db.once("open", function () {
  console.log("Connected to the db successfully");
});

app.use((req, res, next) => {

  res.setHeader('Cache-Control', 'no-store, no-cache, must-revalidate, private');

  next();

});
app.use(cookieParser());
//set view engine
app.set("view engine", "ejs");
//express layouts
var expressLayouts = require("express-ejs-layouts");
app.use(expressLayouts);
app.set("layout", "layouts/layout");

//load assets or public folder--static files and middlewares
app.use(express.static("public"));
app.use(express.json());
app.use(express.urlencoded());

app.get("/", (req, res) => {
  res.render("index");
});
app.get("/index", (req, res) => {
  res.render("index");
});

//teacher and student routes
const teachRoutes = require("./routes/teacherRoutes");
const studRoutes = require("./routes/studentRoutes");
app.use("/teacher", teachRoutes);
app.use("/student", studRoutes);

app.listen(PORT, () => {
  console.log(`Server is running on http://localhost:${PORT}`);
});
