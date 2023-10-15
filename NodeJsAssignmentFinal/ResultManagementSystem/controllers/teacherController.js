const Student = require("../model/student");
const Teacher = require("../model/teacher");
const jsonToken = require("jsonwebtoken");

const SECRET = "secret";

const teacher_login_get = (req, res) => {
  res.render("teacher/teacherlogin");
};

const teacher_login_post = async (req, res) => {
  try {
    const check = await Teacher.findOne({ email: req.body.email });

    if(check)
    {
    if (check && check.password === req.body.password) {
      const token = jsonToken.sign(
        { username: check.username, id: check._id },
        SECRET
      );

      res.cookie("jsonToken", token, {
        httpOnly: true,
        expires: new Date(Date.now() + 2592000),
      });

      const records = await Student.find();
      res.redirect("/teacher/allrecords");
    } else {
      res.redirect("/teacher/login?error=wrongPassword");
    }
  }else{
    res.redirect("/teacher/login?error=teacherNotFound");
  } 
  } catch (error) {
    res.send("An error occurred.");
  }
};

const teacher_signup_get = async (req, res) => {
  res.render("teacher/teachersignup");
};

const teacher_signup_post = async (req, res) => {
  
  const newTeacher = new Teacher({
    email: req.body.email,
    password: req.body.password,
  });

  try{
    await newTeacher.save();
    const token = jsonToken.sign(
      { username: newTeacher.username, id: newTeacher._id },
      SECRET
    );

    res.cookie("jsonToken", token, {
      httpOnly: true,
      expires: new Date(Date.now() + 2592000),
    });
    
   // res.send(`<script>alert("signup successful");</script>`);    
    res.redirect("/teacher/login");
    
  } catch {
    res.send("error");
  }

};




const allrecord_get = async (req, res) => {
  var page=1;

    if(req.query.page){

        page=req.query.page;

    }

    const limit=3;

    const students=await Student.find()

    .sort({roll:1})

    .limit(limit*1)

    .skip((page-1)*limit)

    .exec();

    const no_records=await Student.find();
    
    console.log(students );


    res.render("teacher/allrecords",{students:students,totalPages:Math.ceil(no_records.length/limit)
  });

 }

const addrecord_get = async (req, res) => {
  res.render("teacher/addrecord");
};

const addrecord_post = async (req, res) => {
  const newStudent = new Student({
    roll: req.body.roll,
    name: req.body.name.toLowerCase(),
    dob: req.body.dob,
    score: req.body.score,
  });
  try {
    await newStudent.save();
   // res.send("record success");

    res.redirect("/teacher/allrecords");
  } catch {
    res.send("error");
  }
};

const edit_get = async (req, res) => {
  const user = await Student.findById(req.params.id);
  res.render("teacher/updaterecord", { user: user });
};

const edit_post = async (req, res) => {
  const user = await Student.findByIdAndUpdate(req.params.id, req.body);
  res.redirect("/teacher/allrecords");
};
const delete_get = async (req, res) => {
  await Student.findByIdAndDelete(req.params.id);
  res.redirect("/teacher/allrecords");
};

const logout = async (req, res) => {
  res.clearCookie("jsonToken");
  res.redirect("/index");
};
module.exports = {
  teacher_login_get,
  teacher_login_post,
  teacher_signup_get,
  teacher_signup_post,
  addrecord_get,
  allrecord_get,
  addrecord_post,
  edit_get,
  edit_post,
  delete_get,
  logout,
};
