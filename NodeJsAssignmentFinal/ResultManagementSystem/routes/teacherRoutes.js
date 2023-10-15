var express = require("express");
const router = express.Router();
const authorization= require('../middleware/authorization')
const teacherController = require('../controllers/teacherController');

router.get('/login',teacherController.teacher_login_get);
router.post('/login',teacherController.teacher_login_post);
router.post('/teachersignup',teacherController.teacher_signup_post);
router.get('/teachersignup',teacherController.teacher_signup_get);
router.post('/addrecord',authorization,teacherController.addrecord_post);
router.get('/addrecord',authorization,teacherController.addrecord_get);
router.get('/allrecords',authorization,teacherController.allrecord_get);
router.get('/updaterecord/:id',authorization,teacherController.edit_get);
router.post('/updaterecord/:id',authorization,teacherController.edit_post);
router.get('/delete/:id',authorization,teacherController.delete_get);
router.get('/logout',teacherController.logout);


module.exports = router;